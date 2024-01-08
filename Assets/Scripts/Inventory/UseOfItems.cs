using TMPro;
using UnityEngine;

public class UseOfItems : MonoBehaviour
{
    public static UseOfItems instance;
    [SerializeField] private GameObject letterUI;
    [SerializeField] private TMP_Text letterUIText;

    private void Start()
    {
        instance = this;
    }

    public void Use(Item item)
    {
        if (item.isHealing)
        {
            Debug.Log("ХП повышен на " + item.healingPower);
        }

        if (item.isLetter)
        {
            letterUI.SetActive(true);
            letterUIText.text = item.textLetter;
        }
    }

    public void CloseLetter()
    {
        letterUI.SetActive(false);
    }
}
