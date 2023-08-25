using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Floor : MonoBehaviour
{
    [SerializeField] private List<Segment> defaultSegments;
    
    public void AddEmptySegment(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            defaultSegments[i].SetEmpty();
        }

        for(int i = 0; i >= 0; i--)
        {
            defaultSegments.RemoveAt(i);
        }
    }

    public void AddRandomTrapSegment(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, defaultSegments.Count);
            defaultSegments[index].SetTrap();
            defaultSegments.RemoveAt(index); // delete this object from default segments list
        }
    }

    public void SetRandomRotation()
    {
        transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public void AddFinishSegment()
    {
        for (int i = 0; i < defaultSegments.Count; i++)
        {
            defaultSegments[i].SetFinish();
        }
    }

}
