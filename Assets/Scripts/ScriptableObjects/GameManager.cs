using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(
    fileName = "GameManager",
    menuName = "ScriptableObjects/Create GameManager"
)]
public class GameManager : ScriptableObject
{
    private GameObject pauseMenu = null;

    public void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    public void PauseGame(GameObject menuPrefab = null)
    {
        Time.timeScale = 0f;
        
        if (menuPrefab != null)
        {
            pauseMenu = Instantiate(menuPrefab);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        if (pauseMenu != null)
        {
            Destroy(pauseMenu);
            pauseMenu = null;
        }
    }
}
