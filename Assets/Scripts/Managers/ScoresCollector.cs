using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private int scores;
    public int Scores => scores;    
    protected override void OnBallCollisionSegment(SegmentType type)
    { 
        if(type == SegmentType.Empty)
        {
            scores += levelProgress.CurrentLevel;
            Debug.Log(scores);
            
        }       

    }
}
