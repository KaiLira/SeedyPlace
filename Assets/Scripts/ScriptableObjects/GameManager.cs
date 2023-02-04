using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

[CreateAssetMenu(
    fileName = "GameManager",
    menuName = "ScriptableObjects/Create GameManager"
)]
public class GameManager : ScriptableObject
{
    public GameObject pauseMenu;

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
