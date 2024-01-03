using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _animator.Play("Up");
            _animator.SetBool("down", false);
            _animator.SetBool("up", true);
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _animator.SetBool("up", false);
            _animator.SetBool("down", true);
        }
    }
}
