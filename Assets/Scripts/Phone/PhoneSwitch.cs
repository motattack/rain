using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSwitch : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private Animator phoneAnimator;
    private bool isOn = false;

    void Start()
    {
        phoneAnimator = GetComponent<Animator>();
        SetPhoneDown();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isOn)
            {
                isOn = true;
                panel.SetActive(true);
            }
            SetPhoneUp();
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetPhoneDown();
        }
    }
    
    void SetPhoneUp()
    {
        phoneAnimator.Play("Up");
    }
    
    void SetPhoneDown()
    {
        phoneAnimator.Play("Down");
    }
}
