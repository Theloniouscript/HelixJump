using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelProgress : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;

    [SerializeField] private Image progressBar;
    private float fillAmountStep; // average progress value

    private void Start()
    {
        currentLevelText.text = levelProgress.CurrentLevel.ToString();
        nextLevelText.text = (levelProgress.CurrentLevel +1).ToString();

        progressBar.fillAmount = 0;
        //fillAmountStep = 1 / levelGenerator.FloorAmount;
    }

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if(type == SegmentType.Empty || type == SegmentType.Finish)
        {
            fillAmountStep = 1 / levelGenerator.FloorAmount;
            progressBar.fillAmount += fillAmountStep;
        }
    }
}
