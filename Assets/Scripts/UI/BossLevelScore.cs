using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossLevelScore : MonoBehaviour
{
    public TextMeshProUGUI scoreTotal;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        scoreTotal.text = player.GetComponent<ScoreHandler>().score.ToString();
    }
}
