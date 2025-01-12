using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMob : MonoBehaviour
{
    public Transform Player;

    public float moveSpeed = 3f;
    public float jumpForce = 7f;
    public float followRange = 7f;
    public float stopDistance = 1.1f;
    public float castDistanceDown = 0.5f;
    public float castDistanceForward = 0f;

    public Vector2 groundDetectionBoxSize = new Vector2(0.8f, 0.3f);
    public Vector2 wallDetectionBoxSize = new Vector2(2f, 1f);
    public Vector2 wallDetectionBoxOffset = new Vector2(-0.5f, 0.25f);
    public LayerMask TerrainLayer;

    public bool Grounded = false;
    public bool FacesWall = false;

    void Update()
    {
        Grounded = isGrounded();
        FacesWall = isFacingWall();
        AdjustWallDetectionOffset();

        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);

        if (distanceToPlayer <= followRange && distanceToPlayer > stopDistance)
        {
            FollowPlayer();

            if (FacesWall && Grounded)
            {
                Jump();
            }
        }
    }

    void FollowPlayer()
    {
        Vector2 direction = Player.position - transform.position;
        direction.Normalize();

        transform.position = new Vector2(transform.position.x + direction.x * moveSpeed * Time.deltaTime, transform.position.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
    }

    void AdjustWallDetectionOffset()
    {
        if (Player.position.x > transform.position.x)
        {
            wallDetectionBoxOffset = new Vector2(0.5f, 0.25f);
        }
        else
        {
            wallDetectionBoxOffset = new Vector2(-0.5f, 0.25f);
        }
    }

    bool isGrounded()
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

     bool isFacingWall()
    {
        Vector2 boxPosition = (Vector2)transform.position + wallDetectionBoxOffset;
        return Physics2D.BoxCast(boxPosition, wallDetectionBoxSize, 0, -transform.right, castDistanceForward, TerrainLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position - transform.up * castDistanceDown, groundDetectionBoxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + wallDetectionBoxOffset - (Vector2)(transform.right * castDistanceForward), wallDetectionBoxSize);
    }   
}

