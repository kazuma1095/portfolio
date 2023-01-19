using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("ButtonÇì¸ÇÍÇÈ")]
    // èÊÇÈÉ{É^Éì
    [SerializeField] private GameObject rideButton;
    // ç~ÇËÇÈÉ{É^Éì
    [SerializeField] private GameObject getOffButton;

    [Header("PlayerÇÃà íu")]
    [SerializeField] private Transform playerPosition;

    [Header("äeãqé‘Ç÷ÇÃì]ëóà íu")]
    [SerializeField] private Transform ridePosition1;
    [SerializeField] private Transform ridePosition2;

    [Header("ç~é‘à íu")]
    [SerializeField] private Transform getOffPosition;

    // Ç«Ç±ÇÃãqé‘Ç…èÊÇÈÇ©(î‘çÜ)
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

    // èÊÇÈ
    public void ride()
    {
        if (rideNumber == 1) playerPosition.position = ridePosition1.position;
        if (rideNumber == 2) playerPosition.position = ridePosition2.position;
    }
    // ç~ÇËÇÈ
    public void getOff()
    {
        playerPosition.position = getOffPosition.position;
    }
}
