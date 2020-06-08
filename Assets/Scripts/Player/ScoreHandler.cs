using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public float score;

    public void AddScore(float amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }


}
