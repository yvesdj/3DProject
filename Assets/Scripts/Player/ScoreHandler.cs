using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public float score;

    public TextMeshProUGUI scoreTotal;
    public TextMeshProUGUI scoreAdded;

    private void Start()
    {
        score = 0;
    }

    public void AddScore(float amount)
    {
        score += amount;
        scoreAdded.text = "+" + amount.ToString();
        UpdateTotalScore();
        Debug.Log("Score: " + score);
    }

    public void UpdateTotalScore()
    {
        scoreTotal.text = score.ToString();
    }


}
