using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : OneColliderTrigger
{
    protected override void OnOneTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
}
