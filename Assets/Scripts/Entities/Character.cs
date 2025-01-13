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

    [SerializeField]
    LayerMask TerrainLayer;

    [SerializeField]
    float castDistanceDown = 0.5f;

    [SerializeField]
    Vector2 groundDetectionBoxSize = new Vector2(0.8f, 0.3f);

    public bool grounded = false;

    Rigidbody2D RigidBody;

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
        grounded = IsGrounded();

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

        if(Input.GetKey(KeyCode.Space) && grounded)
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
        if (Physics2D.BoxCast(transform.position, groundDetectionBoxSize, 0, -transform.up, castDistanceDown, TerrainLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

        void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistanceDown, groundDetectionBoxSize);
    }
}
