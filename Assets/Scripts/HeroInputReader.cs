using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private HeroInputAction _inputAction;

    private void Awake()
    {
        _inputAction = new HeroInputAction();
        _inputAction.Hero.movement.performed += OnMovement;
        _inputAction.Hero.movement.canceled += OnMovement;
    }

    private void OnEnable()
    {
        _inputAction.Enable();
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }
}
