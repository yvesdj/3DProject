using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public float victoryDelay = 2f;
    public GameObject victoryUI;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        Invoke("Victory", victoryDelay);
    }

    void Victory()
    {
        victoryUI.SetActive(true);
        PauseMenu.gameIsPaused = true;
        Time.timeScale = 0f;
        
    }
}
