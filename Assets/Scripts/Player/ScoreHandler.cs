using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public float score;
    public float addedDisplayTime;

    public TextMeshProUGUI scoreTotal;
    public TextMeshProUGUI scoreAdded;
    public Animator animator;

    private void Start()
    {
        score = 0;
    }

    public void AddScore(float amount)
    {
        animator.SetBool("IsShowing", true);
        score += amount;
        scoreAdded.text = "+" + amount.ToString();
        UpdateTotalScore();
        StartCoroutine(FadeScoreAdded());
        
    }

    public void UpdateTotalScore()
    {
        scoreTotal.text = score.ToString();
    }

    IEnumerator FadeScoreAdded()
    {
        yield return new WaitForSeconds(addedDisplayTime);

        animator.SetBool("IsShowing", false);
    }
}
