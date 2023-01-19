using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotiveContoroller : MonoBehaviour
{
    [Header("機関車の最大移動速度")]
    public float maxSpeed = 100.0f;

    [Header("機関車の加速度(単位は1秒ではなく1フレーム)")]
    public float acceralate = 0.002f;

    [Header("機関車が止まってから走り出すまでの時間")]
    public float runTime = 10;
    private float timeCount = 0;

    [Header("アニメーションのスピード補正")]
    public float animSpeed = 7;

    // maxSpeedカウント用(i:加速、j:減速)
    private int i = 0, j = 0;

    // maxSpeedを数える用(アニメーションのスピード調節にも使用)
    [HideInInspector] public float speed = 0.0f;

    // Smokeを出すかどうかの判断
    public static bool isSmoke = false;

    private void Start()
    {
        // 初めにブレーキを踏んだ状態にする(減速の最大値をjが取る)
        j = (int)maxSpeed;
    }

    void FixedUpdate()
    {
        // ブレーキを踏んでいない状態なら
        if (Brake.isBrake == false)
        {
            //  maxSpeed分だけ繰り返し加速させる
            if (i != maxSpeed)
            {
                speed += acceralate;
                i++;
            }

            // Smokeを出していないなら出す
            if (!isSmoke)
            {
                isSmoke = true;
            }
        }

        // ブレーキを踏んでいる状態なら
        if (Brake.isBrake == true)
        {
            //  加速した分だけ減速させる
            if (j != maxSpeed)
            {
                speed += (-1) * acceralate;
                j++;
            }

            //  完全にspeedを0にする
            if (j == maxSpeed)
            {
                speed = 0.0f;

                // Smokeを消す
                isSmoke = false;

                timeCount += Time.deltaTime;

                //  止まった後runTime秒後に再出発する
                timeCount += Time.deltaTime;
                if (timeCount >= runTime)
                {
                    LocomotiveReset();
                    timeCount = 0;
                }
            }
        }
    }

    private void LocomotiveReset()
    {
        // 加速、減速の初期化
        i = 0;
        j = 0;
        
        // ブレーキを再び離す
        Brake.isBrake = false;
    }
}
