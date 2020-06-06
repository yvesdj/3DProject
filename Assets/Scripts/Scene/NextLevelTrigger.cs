using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour, IEventTrigger
{
    public bool hasBeenTriggered { get; set; }

    void Start()
    {
        hasBeenTriggered = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        hasBeenTriggered = true;
        GoToNextLevel();
    }

    void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
