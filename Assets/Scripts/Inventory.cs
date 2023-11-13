using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<Slot> _slots = new List<Slot>();
    public static Slot SelectedSlot = null;

    private TMP_Text _lvlText;
    private TMP_Text _moneyText;
    private RectTransform _barRectTransform;

    private void Start()
    {
        _lvlText = GetComponentsInChildren<TMP_Text>()[0];
        _moneyText = GetComponentsInChildren<TMP_Text>()[1];

        _barRectTransform = GetComponentsInChildren<Image>()[3].GetComponent<RectTransform>();

        _barRectTransform.localScale = new Vector3(DB.LvlProgress, 1, 1);
        _lvlText.text = "Уровень " + DB.Lvl;
        _moneyText.text = DB.Money + " руб.";

        _slots = GetComponentsInChildren<Slot>().ToList();

        int i = 0;
        foreach (Slot slot in _slots)
        {
            slot.FillSlot(i);
            i++;
        }
    }
}
