using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    //  �u���[�L�𓥂񂾂��ǂ����̔��f
    public static bool isBrake = true;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Brake")
        {
            // �u���[�L�𓥂�
            isBrake = true;
        }
    }
}
