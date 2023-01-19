using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBaseScript : MonoBehaviour
{
    [Header("機関車のController")]
    [SerializeField] private LocomotiveContoroller LC;

    [Header("車両の種類に合ったPathCreator")]
    public PathCreator pathCreator;

    // Path上での移動距離
    private float moveDistance;

    void Update()
    {
        moveDistance += LC.speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(moveDistance);
        transform.rotation = pathCreator.path.GetRotationAtDistance(moveDistance);
    }
}
