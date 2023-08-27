
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : BallEvents
{
    [SerializeField] private ScoresCollector scoresCollector;
    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;   

    private int recScore;
    public int RecScore => recScore;

    protected override void Awake()
    {       
        base.Awake();
        Load(); 
        

    }
#if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1) == true) // reset all data and reload scene
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2) == true) // reload with saving level info
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
#endif
    protected override void OnBallCollisionSegment(SegmentType type)
    {   
        if (type == SegmentType.Finish)
        {
            currentLevel++;

            if (recScore < scoresCollector.Scores)
            {
                recScore = scoresCollector.Scores;
            }

            Save();                    
                
        }
    }   
    
    private void Save()
    {
        PlayerPrefs.SetInt("LevelProgress: currentLevel", currentLevel);
        PlayerPrefs.SetInt("LevelProgress: recScore", recScore);
        Debug.Log("RecScore on Save: " + recScore);
    }

    private void Load()
    {
        currentLevel = PlayerPrefs.GetInt("LevelProgress: currentLevel", 1);
        recScore = PlayerPrefs.GetInt("LevelProgress: recScore", recScore);

    }

#if UNITY_EDITOR
    private void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
#endif
}
