using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("カメラの位置オブジェクト")]
    public Transform viewPoint;
    [Header("視点移動の速度")]
    public float mouseSensitivity = 1f;

    // ユーザーのマウス入力を格納
    private Vector2 mouseInput;
    // y軸の回転を格納
    private float verticalMouseInput;
    // カメラ
    private Camera cam;

    // プレイヤーの入力を格納（移動）
    private Vector3 moveDir;
    // 進む方向を格納する変数
    private Vector3 movement;
    // 実際の移動速度
    private float activeMoveSpeed = 4;

    [Header("ジャンプ力 ")]
    public Vector3 jumpForce = new Vector3(0, 6, 0);
    [Header("地面に向けてレイを飛ばすオブジェクト ")]
    public Transform groundCheckPoint;
    [Header("地面だと認識するレイヤー ")]
    public LayerMask groundLayers;

    // Rigidbodyコンポーネント
    private Rigidbody rb;

    // 機関車に乗ったかどうかを判断
    private bool isRide = false;

    [Header("機関車で位置を固定するために親となるオブジェクトが必要")]
    [Header("親とするオブジェクト")]
    [SerializeField] private GameObject parentObject1;
    [SerializeField] private GameObject parentObject2;

    [Header("UI")]
    [SerializeField] private ButtonController BC;

    private void Start()
    {
        // 変数にメインカメラを格納
        cam = Camera.main;

        // Rigidbodyを格納
        rb = GetComponent<Rigidbody>();

        // Buttonの表示を初期化
        BC.rideButtonDisappear();
        BC.getOffButtonDisappear();
    }

    private void Update()
    {
        // 視点移動関数
        PlayerRotate();

        // 機関車に乗ってないときに実行
        if (!isRide)
        {
            // 移動関数
            PlayerMove();

            // ジャンプ関数を呼ぶ
            Jump();
        }
        else if (isRide)
        {
            rb.velocity = Vector3.zero;
        }
    }

    // Update関数が呼ばれた後に実行される
    private void LateUpdate()
    {
        // カメラをプレイヤーの子にするのではなく、スクリプトで位置を合わせる
        cam.transform.position = viewPoint.position;
        cam.transform.rotation = viewPoint.rotation;
    }

    // Playerの横回転と縦の視点移動を行う
    public void PlayerRotate()
    {
        // 変数にユーザーのマウスの動きを格納
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        // 横回転を反映(transform.eulerAnglesはオイラー角としての角度が返される)
        transform.rotation = Quaternion.Euler
            (transform.eulerAngles.x, 
            transform.eulerAngles.y + mouseInput.x, // マウスのx軸の入力を足す
            transform.eulerAngles.z);


        // 変数にy軸のマウス入力分の数値を足す
        verticalMouseInput += mouseInput.y;

        // 変数の数値を丸める（上下の視点制御）
        verticalMouseInput = Mathf.Clamp(verticalMouseInput, -60f, 60f);

        // 縦の視点回転を反映(-を付けないと上下反転してしまう)
        viewPoint.rotation = Quaternion.Euler
            (-verticalMouseInput, 
            viewPoint.transform.rotation.eulerAngles.y, 
            viewPoint.transform.rotation.eulerAngles.z);
    }



    // Playerの移動
    public void PlayerMove()
    {
        // 変数の水平と垂直の入力を格納する（wasdや矢印の入力）
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 
            0, Input.GetAxisRaw("Vertical"));

        // ゲームオブジェクトのｚ軸とx軸に入力された値をかけると進む方向が出せる
        movement = ((transform.forward * moveDir.z) + (transform.right * moveDir.x)).normalized;

        // 現在位置に進む方向＊移動スピード＊フレーム間秒数を足す
        transform.position += movement * activeMoveSpeed * Time.deltaTime;
    }


    // 地面についているならtrue
    public bool IsGround()
    {
        return Physics.Raycast(groundCheckPoint.position, Vector3.down, 0.25f, groundLayers);
    }

    // Playerの跳躍
    public void Jump()
    {
        // ジャンプできるのか判定
        if (IsGround() && Input.GetKeyDown(KeyCode.Space))
        {
            // 瞬間的に真上に力を加える
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    // 物理的接触による判定
    private void OnCollisionEnter(Collision collision)
    {
        // どの客車に乗るかを決める
        if (collision.gameObject.name == "足場(客車_1)")
        {
            BC.rideNumber = 1;
        }
        if (collision.gameObject.name == "足場(客車_2)")
        {
            BC.rideNumber = 2;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // 駅_足場に乗っていて機関車が完全に停止している場合
        // 機関車に乗るためのボタンを表示
        if ((collision.gameObject.name == "足場(客車_1)" ||
            collision.gameObject.name == "足場(客車_2)") &&
            !LocomotiveContoroller.isSmoke)
        {
            // 乗るボタンを出現させる
            BC.rideButtonAppear();
        }
        else
        {
            // 乗るボタンを消す
            BC.rideButtonDisappear();
        }


        // 機関車に乗っていて機関車が完全に停止している場合(床(上)は客車の床)
        // 機関車を降りるためのボタンを表示
        if (collision.gameObject.name == "床(上)" &&
            !LocomotiveContoroller.isSmoke)
        {
            // 降りるボタンを出現させる
            BC.getOffButtonAppear();
        }
        else
        {
            // 降りるボタンを消す
            BC.getOffButtonDisappear();
        }

        // 機関車に乗っている場合(床(上)は客車の床)
        // 親子関係を作る
        if (transform.parent == null && 
            collision.gameObject.name == "床(上)")
        {
            // 客車_1と親子関係を作る
            if (BC.rideNumber == 1)
            {
                // 機関車_客車を親として親子関係を作るスクリプト
                this.transform.parent = parentObject1.transform;

                // 乗ったのでtrueにする
                isRide = true;
            }

            // 客車_2と親子関係を作る
            if (BC.rideNumber == 2)
            {
                // 機関車_客車を親として親子関係を作るスクリプト
                this.transform.parent = parentObject2.transform;

                // 乗ったのでtrueにする
                isRide = true;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // 機関車に乗っている場合(床(上)は客車の床)
        if (transform.parent != null && 
            collision.gameObject.name == "床(上)")
        {
            // 親子関係の解消
            transform.parent = null;

            // 降りたのでfalseにする
            isRide = false;

            // playerの角度をリセット
            transform.rotation = Quaternion.identity;

            // 物理現象を適応させる状態に戻す
            rb.isKinematic = false;
        }
    }
}