using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreSaver : MonoBehaviour
{
    public NextLevelTrigger saveTrigger;
    public HighscoreTable highscoreTable;
    public ScoreHandler playerScore;

    public bool isSaved;

    void Awake()
    {
        playerScore = GetComponent<ScoreHandler>();
    }

    void Start()
    {
        isSaved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSaved == false)
        {
            Debug.Log("not triggered");
        }
        
        if (saveTrigger.HasBeenTriggered && !isSaved)
        {
            Debug.Log("Saving");
            
            highscoreTable.AddHighscoreEntry(playerScore.score);
            isSaved = true;
        }
    }
}
