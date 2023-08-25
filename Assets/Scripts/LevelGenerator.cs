using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;
    [SerializeField] private int amountEmptySegment;
    [SerializeField] private int minAmountTrapSegment;
    [SerializeField] private int maxAmountTrapSegment;

    [Header("Settings")]
    [SerializeField] private int defaultFloorAmount;
    [SerializeField] private float floorHeight;

    private float floorAmount = 0;

    public Transform BALLTRANSFORM;

    private void Start()
    {
        Generate(1);
        BALLTRANSFORM.position = new Vector3(BALLTRANSFORM.position.x, floorAmount * floorHeight - floorHeight, BALLTRANSFORM.position.z);
        
    }

    public void Generate(int level)
    {
        DestroyChild();
        floorAmount = defaultFloorAmount + level;
        axis.transform.localScale = new Vector3(1, floorAmount * floorHeight + floorHeight, 1);

        for(int i = 0; i < floorAmount; i++)
        {
            Floor floor = Instantiate(floorPrefab, transform);
            floor.transform.Translate(0, i * floorHeight, 0);
            floor.name = "Floor" + i;

            if(i == 0) // first floor
            {
                floor.AddFinishSegment();
            }

            if(i > 0 && i < floorAmount - 1) // middle floors
            {
                floor.SetRandomRotation();
                floor.AddEmptySegment(amountEmptySegment);
                floor.AddRandomTrapSegment(Random.Range(minAmountTrapSegment, maxAmountTrapSegment + 1));
            }

            if(i == floorAmount -1) // highest floor
            {
                floor.AddEmptySegment(amountEmptySegment);
            }

            
            
        }

    }

    private void DestroyChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) == axis) continue;
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
