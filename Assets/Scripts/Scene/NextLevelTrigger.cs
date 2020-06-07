using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour, IEventTrigger
{
    public bool HasBeenTriggered { get; set; }

    void Start()
    {
        HasBeenTriggered = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        HasBeenTriggered = true;
        GoToNextLevel();
    }

    void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
