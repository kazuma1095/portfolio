using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("Button������")]
    // ���{�^��
    [SerializeField] private GameObject rideButton;
    // �~���{�^��
    [SerializeField] private GameObject getOffButton;

    [Header("Player�̈ʒu")]
    [SerializeField] private Transform playerPosition;

    [Header("�e�q�Ԃւ̓]���ʒu")]
    [SerializeField] private Transform ridePosition1;
    [SerializeField] private Transform ridePosition2;

    [Header("�~�Ԉʒu")]
    [SerializeField] private Transform getOffPosition;

    // �ǂ��̋q�Ԃɏ�邩(�ԍ�)
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

    // ���
    public void ride()
    {
        if (rideNumber == 1) playerPosition.position = ridePosition1.position;
        if (rideNumber == 2) playerPosition.position = ridePosition2.position;
    }
    // �~���
    public void getOff()
    {
        playerPosition.position = getOffPosition.position;
    }
}
