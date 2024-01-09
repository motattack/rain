using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    [SerializeField] private GameObject pauseMenuIU;
    [SerializeField] private GameObject[] otherUI;
    private bool[] prevUIState;

    private void Start()
    {
        prevUIState = new bool[otherUI.Length];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuIU.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;

        if (otherUI != null)
        {
            for (int i = 0; i < otherUI.Length; i++)
            {
                otherUI[i].SetActive(prevUIState[i]);
            }
        }
    }

    void Pause()
    {
        if (otherUI != null)
        {
            for (int i = 0; i < otherUI.Length; i++)
            {
                prevUIState[i] = otherUI[i].activeSelf;
                otherUI[i].SetActive(false);
            }
        }

        pauseMenuIU.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameMenu");
    }
}
