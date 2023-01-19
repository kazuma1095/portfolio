using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotiveContoroller : MonoBehaviour
{
    [Header("�@�֎Ԃ̍ő�ړ����x")]
    public float maxSpeed = 100.0f;

    [Header("�@�֎Ԃ̉����x(�P�ʂ�1�b�ł͂Ȃ�1�t���[��)")]
    public float acceralate = 0.002f;

    [Header("�@�֎Ԃ��~�܂��Ă��瑖��o���܂ł̎���")]
    public float runTime = 10;
    private float timeCount = 0;

    [Header("�A�j���[�V�����̃X�s�[�h�␳")]
    public float animSpeed = 7;

    // maxSpeed�J�E���g�p(i:�����Aj:����)
    private int i = 0, j = 0;

    // maxSpeed�𐔂���p(�A�j���[�V�����̃X�s�[�h���߂ɂ��g�p)
    [HideInInspector] public float speed = 0.0f;

    // Smoke���o�����ǂ����̔��f
    public static bool isSmoke = false;

    private void Start()
    {
        // ���߂Ƀu���[�L�𓥂񂾏�Ԃɂ���(�����̍ő�l��j�����)
        j = (int)maxSpeed;
    }

    void FixedUpdate()
    {
        // �u���[�L�𓥂�ł��Ȃ���ԂȂ�
        if (Brake.isBrake == false)
        {
            //  maxSpeed�������J��Ԃ�����������
            if (i != maxSpeed)
            {
                speed += acceralate;
                i++;
            }

            // Smoke���o���Ă��Ȃ��Ȃ�o��
            if (!isSmoke)
            {
                isSmoke = true;
            }
        }

        // �u���[�L�𓥂�ł����ԂȂ�
        if (Brake.isBrake == true)
        {
            //  ������������������������
            if (j != maxSpeed)
            {
                speed += (-1) * acceralate;
                j++;
            }

            //  ���S��speed��0�ɂ���
            if (j == maxSpeed)
            {
                speed = 0.0f;

                // Smoke������
                isSmoke = false;

                timeCount += Time.deltaTime;

                //  �~�܂�����runTime�b��ɍďo������
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
        // �����A�����̏�����
        i = 0;
        j = 0;
        
        // �u���[�L���Ăї���
        Brake.isBrake = false;
    }
}
