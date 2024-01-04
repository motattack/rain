using UnityEngine;
using UnityEngine.UI;

public class PhoneRunApp : MonoBehaviour
{
    [SerializeField] private GameObject app;
    private Button _runButton;

    private void Start()
    {
        _runButton = GetComponent<Button>();
        _runButton.onClick.AddListener(Run);
    }

    private void Run()
    {
        Phone.instance.AddApp(app);
    }
}
