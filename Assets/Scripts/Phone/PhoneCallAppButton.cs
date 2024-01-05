using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneCallAppButton : MonoBehaviour
{
    [SerializeField] private char symbol;
    [SerializeField] private TMP_InputField input;
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(AddSymbol);
    }

    public void AddSymbol()
    {
        if (symbol == '<')
        {
            if (input.text.Length > 0)
            {
                input.text = input.text.Substring(0, input.text.Length - 1);
            }
        }
        else
        {
            input.text += symbol;
        }
    }
}
