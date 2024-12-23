using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMob : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 3f;
    public float followRange = 7f;
    public float stopDistance = 1f;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);

        if (distanceToPlayer <= followRange && distanceToPlayer > stopDistance)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        Vector2 direction = Player.position - transform.position;
        direction.Normalize();

        transform.position = new Vector2(transform.position.x + direction.x * moveSpeed * Time.deltaTime, transform.position.y);
    }
}

