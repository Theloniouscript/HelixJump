using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : OneColliderTrigger
{

    [SerializeField] private GameObject splashPrefab;
    [SerializeField] private GameObject visualModel;
    [SerializeField] private LevelGenerator level;
    private Vector3 Pos;

    protected override void OnOneTriggerEnter(Collider other)
    {
        Segment segment = other.GetComponent<Segment>();
        Pos = new Vector3(visualModel.transform.position.x, visualModel.transform.position.y, visualModel.transform.position.z);


        if (segment.Type == SegmentType.Empty)
        {
            Debug.Log("No splash! ");
            return;
        }
        else
        {
            GameObject splash = Instantiate(splashPrefab, Pos, Quaternion.Euler(-90, 0, 0));
            Debug.Log("Splash! ");

            splash.transform.parent = level.transform;
        }

    }


}
