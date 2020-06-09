using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour, IEventTrigger
{
    public bool HasBeenTriggered { get; set; }
    public float delay = 2f;

    void Start()
    {
        HasBeenTriggered = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        HasBeenTriggered = true;
        StartCoroutine(GoToNextLevel());
    }

    IEnumerator GoToNextLevel()
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
