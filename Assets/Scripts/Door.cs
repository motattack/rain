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
            Load();
        }
    }

    private void OnMouseDown()
    {
        Load();
    }

    private void Load()
    {
        _gameData.position = nextLevelPos;
        _storage.Save(_gameData);
        SceneManager.LoadScene(nextSceneName);
    }
}
