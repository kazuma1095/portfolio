using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBaseScript : MonoBehaviour
{
    [Header("‹@ŠÖÔ‚ÌController")]
    [SerializeField] private LocomotiveContoroller LC;

    [Header("Ô—¼‚Ìí—Ş‚É‡‚Á‚½PathCreator")]
    public PathCreator pathCreator;

    // Pathã‚Å‚ÌˆÚ“®‹——£
    private float moveDistance;

    void Update()
    {
        moveDistance += LC.speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(moveDistance);
        transform.rotation = pathCreator.path.GetRotationAtDistance(moveDistance);
    }
}
