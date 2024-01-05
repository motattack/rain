using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Storage _storage;
    private GameData _gameData;

    private void Start()
    {
        _storage = new Storage();
        Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            Load();
        }
    }

    public void Save()
    {
        _gameData.position = transform.position;
        _gameData.rotation = transform.rotation;
        Debug.Log("Игра сохранена");
        _animator.Play("Saving");
        _storage.Save(_gameData);
    }

    public void Load()
    {
        Debug.Log("Игра загружена");
        _animator.Play("Load");
        _gameData = (GameData)_storage.Load(new GameData());
        
        transform.position = _gameData.position;
        transform.rotation = _gameData.rotation;
    }
}
