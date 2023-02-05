using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Unity.VisualScripting;

[CreateAssetMenu(
    fileName = "GameManager",
    menuName = "ScriptableObjects/Create GameManager"
)]
public class GameManager : ScriptableObject
{
    public GameObject pauseMenu;
    public GameObject blackScreen;
    public GameObject gameOver;

    public void OnDeath()
    {
        Time.timeScale = 0f;
        Instantiate(gameOver);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Instantiate(pauseMenu);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Destroy(GameObject.FindWithTag("PauseMenu"));
    }

    public void OnPauseButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            if (!GameObject.FindWithTag("PauseMenu"))
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void OnSelectButton(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            ReloadScene();
        }
    }
}