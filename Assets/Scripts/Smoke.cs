using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [Header("機関車のSmokeパーティクル")]
    [SerializeField] private ParticleSystem[] smoke;

    // 煙を出したかどうか
    private bool isPlay = false; 

    void Update()
    {
        if (LocomotiveContoroller.isSmoke && !isPlay)
        {
            for (int i = 0; i < smoke.Length; i++)
            {
                smoke[i].Play();
            }

            isPlay = true;
        }

        if (!LocomotiveContoroller.isSmoke && isPlay)
        {
            for (int i = 0; i < smoke.Length; i++)
            {
                smoke[i].Stop();
            }

            isPlay = false;
        }
    }
}
