using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("Buttonを入れる")]
    // 乗るボタン
    [SerializeField] private GameObject rideButton;
    // 降りるボタン
    [SerializeField] private GameObject getOffButton;

    [Header("Playerの位置")]
    [SerializeField] private Transform playerPosition;

    [Header("各客車への転送位置")]
    [SerializeField] private Transform ridePosition1;
    [SerializeField] private Transform ridePosition2;

    [Header("降車位置")]
    [SerializeField] private Transform getOffPosition;

    // どこの客車に乗るか(番号)
    [HideInInspector] public int rideNumber = 0;

    public void rideButtonAppear()
    {
        rideButton.SetActive(true);
    }

    public void rideButtonDisappear()
    {
        rideButton.SetActive(false);
    }

    public void getOffButtonAppear()
    {
        getOffButton.SetActive(true);
    }

    public void getOffButtonDisappear()
    {
        getOffButton.SetActive(false);
    }

    // 乗る
    public void ride()
    {
        if (rideNumber == 1) playerPosition.position = ridePosition1.position;
        if (rideNumber == 2) playerPosition.position = ridePosition2.position;
    }
    // 降りる
    public void getOff()
    {
        playerPosition.position = getOffPosition.position;
    }
}
