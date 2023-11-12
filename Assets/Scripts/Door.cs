using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string nextSceneName;

    private void OnMouseDown()
    {
        if(PauseMenu.isPaused) return;
        SceneManager.LoadScene(nextSceneName);
    }
}
