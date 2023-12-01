using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPause();
    }

    // Toggles the pause screen.
    void TogglePauseScreen()
    {
        if (pauseScreen.activeSelf == true)
        {
            pauseScreen.gameObject.SetActive(false);
            SetTimeScale(1);
            isPaused = false;
        } else
        {
            pauseScreen.gameObject.SetActive(true);
            SetTimeScale(0);
            isPaused = true;
        }
    }

    // Resumes the game. (for the resume button in pause)
    public void ResumeGame()
    {
        pauseScreen.gameObject.SetActive(false);
        SetTimeScale(1);
        isPaused = false;
    }

    // Quits the game.
    public void QuitGame()
    {
        Debug.Log("Quitting game!");
        Application.Quit();
    }


    // Sets the time scale.
    // Usually 0 or 1 to pause/resume game
    void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    // Checking to see if player pressed escape to pause the game.
    void CheckForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            TogglePauseScreen();
        } else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            TogglePauseScreen();
        }
    }
}