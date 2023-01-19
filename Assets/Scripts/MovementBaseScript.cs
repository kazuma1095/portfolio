using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBaseScript : MonoBehaviour
{
    [Header("�@�֎Ԃ�Controller")]
    [SerializeField] private LocomotiveContoroller LC;

    [Header("�ԗ��̎�ނɍ�����PathCreator")]
    public PathCreator pathCreator;

    // Path��ł̈ړ�����
    private float moveDistance;

    void Update()
    {
        moveDistance += LC.speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(moveDistance);
        transform.rotation = pathCreator.path.GetRotationAtDistance(moveDistance);
    }
}
