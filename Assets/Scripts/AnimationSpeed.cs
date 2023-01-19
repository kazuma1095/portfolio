using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationSpeed : MonoBehaviour
{
    [Header("機関車のController")]
    // 移動速度を取ってくる用
    public LocomotiveContoroller LC;

    // アニメーションコンポーネント
    private Animator p_Animator;

    // アニメーションの歩き速度の調整パラメータ名
    private const string ps_Speed = "Speed";

    void Start()
    {
        // アニメーターの参照を取得する
        p_Animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        // アニメーションの速度を[WalkSpeed]パラメータに設定する
        p_Animator.SetFloat(ps_Speed, LC.speed * LC.animSpeed);
    }
}
