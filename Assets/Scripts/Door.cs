using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 nextLevelPos;
    [SerializeField] private string nextSceneName;
    [SerializeField] private bool isButton = false;
    private Storage _storage;
    private GameData _gameData;

    private void Start()
    {
        _storage = new Storage();
        _gameData = new GameData();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isButton)
        {
            _gameData.position = nextLevelPos;
            _storage.Save(_gameData);
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void OnMouseDown()
    {
        _gameData.position = nextLevelPos;
        _storage.Save(_gameData);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == nextSceneName)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            
            if (player != null)
            {
                player.transform.position = nextLevelPos;
            }
            
            
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
