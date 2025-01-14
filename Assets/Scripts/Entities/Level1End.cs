using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1End : MonoBehaviour
{

	[SerializeField]
	GameObject Player;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == Player)
		{
			if (CastleAPI.LoadMaxLevel() < 1)
			{
				CastleAPI.SaveMaxLevel(1);
			}

			SceneManager.LoadScene("LevelSelect");
		}
	}

}
