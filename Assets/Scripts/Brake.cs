using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake : MonoBehaviour
{
    //  ブレーキを踏んだかどうかの判断
    public static bool isBrake = true;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Brake")
        {
            // ブレーキを踏む
            isBrake = true;
        }
    }
}
