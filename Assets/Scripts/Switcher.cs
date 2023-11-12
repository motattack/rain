using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public GameObject target;

    private void OnMouseDown() 
    {
        target.SetActive(!target.activeSelf);
    }
}
