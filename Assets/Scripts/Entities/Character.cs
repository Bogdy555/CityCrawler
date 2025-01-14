using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
	[SerializeField]
	float Force = 10.0f;

	[SerializeField]
	float FallForce = 10.0f;

	[SerializeField]
	float TopSpeed = 10.0f;

	[SerializeField]
	float TopFallSpeed = 15.0f;

	[SerializeField]
	float JumpSpeed = 10.0f;

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
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("LevelSelect");
		}

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

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Mobs")
		{
			SceneManager.LoadScene("LevelSelect");
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position - transform.up * castDistanceDown, groundDetectionBoxSize);
	}
}
