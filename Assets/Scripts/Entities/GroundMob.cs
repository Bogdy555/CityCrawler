using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMob : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 3f;
    public float followRange = 7f;
    public float stopDistance = 2f;
    public Vector2 boxSize;
    public float castDistance;
    public bool Grounded = false;
    public LayerMask TerrainLayer;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);

        if (distanceToPlayer <= followRange && distanceToPlayer > stopDistance)
        {
            FollowPlayer();
        }

        Grounded = isGrounded();
    }

    void FollowPlayer()
    {
        Vector2 direction = Player.position - transform.position;
        direction.Normalize();

        transform.position = new Vector2(transform.position.x + direction.x * moveSpeed * Time.deltaTime, transform.position.y);
    }

    bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, TerrainLayer))
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
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
    
}

