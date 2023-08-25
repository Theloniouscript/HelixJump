using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallEvents : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    protected virtual void Awake()
    {
        ballController.CollisionSegment.AddListener(OnBallCollisionSegment);
    }

    private void OnDestroy()
    {
        ballController.CollisionSegment.RemoveListener(OnBallCollisionSegment);
    }

    // Virtual Events
    protected virtual void OnBallCollisionSegment(SegmentType type) { }
    
}
