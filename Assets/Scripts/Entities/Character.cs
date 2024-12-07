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

    public int health;

    Rigidbody2D RigidBody = null;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        updatePosition();
    }

    public void newSave()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    public void updatePosition()
    {
        if (StaticData.newData == true)
        {
            health = StaticData.health ?? health;
            transform.position = StaticData.position ?? transform.position;

            StaticData.newData = false;
        }
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SaveSystem.SavePlayer(this);
        }
    }

    bool IsGrounded()
    {
        return true;
    }
}
