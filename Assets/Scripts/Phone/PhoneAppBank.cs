using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneAppBank : MonoBehaviour
{
    [SerializeField] private TMP_Text balance;
    
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            int currentBalance = Hero.instance.balance;
            balance.text = currentBalance.ToString() + " rub.";
        }
    }
}
