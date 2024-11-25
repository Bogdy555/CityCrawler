using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    float Force = 10.0f;

    [SerializeField]
    float FallForce = 3.0f;

    [SerializeField]
    float TopSpeed = 5.0f;

    [SerializeField]
    float TopFallSpeed = 10.0f;

    [SerializeField]
    float JumpSpeed = 5.0f;

    Rigidbody2D RigidBody;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) && RigidBody.velocity.x > -TopSpeed)
        {
            RigidBody.AddForce(new Vector2(-1.0f, 0.0f) * Force);
        }

        if (Input.GetKey(KeyCode.D) && RigidBody.velocity.x < TopSpeed)
        {
            RigidBody.AddForce(new Vector2(1.0f, 0.0f) * Force);
        }

        if (Input.GetKey(KeyCode.S) && RigidBody.velocity.y > -TopFallSpeed)
        {
            RigidBody.AddForce(new Vector2(0.0f, -1.0f) * FallForce);
        }

        if(Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            RigidBody.velocity = new Vector2(RigidBody.velocity.x, JumpSpeed);
        }
    }

    bool IsGrounded()
    {
        return true;
    }
}
