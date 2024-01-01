using System;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField] private float Acceleration;
    [SerializeField] private float RotationPower;
    [SerializeField] private float SlipPower;

    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetSlipVector()
    {
        return Vector3.Project(RB.velocity.normalized, transform.right);
    }

    void Slip(Vector2 SlipVector, float Power)
    {
        RB.AddForce(-SlipVector * Power);
    }

    void PlayerController()
    {
        float Vertical = Input.GetAxis("Vertical");
        float Multiply = Vertical >= 0 ? 1 : 0.5f;
        RB.AddForce(transform.up * (Acceleration * Input.GetAxisRaw("Vertical") * Multiply));
        Multiply = Vertical >= 0 ? 1 : -1;
        RB.AddTorque(-Input.GetAxisRaw("Horizontal") * Multiply * (RB.velocity.magnitude / 2) * RotationPower);
        Slip(GetSlipVector(), SlipPower);
    }

    private void FixedUpdate()
    {
        if (RB)
        {
            PlayerController();
        }
    }
}
