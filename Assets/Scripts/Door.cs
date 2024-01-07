using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 nextLevelPos;
    [SerializeField] private string nextSceneName;
    [SerializeField] private bool isButton = false;


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
