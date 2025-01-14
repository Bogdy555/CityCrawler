using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2End : MonoBehaviour
{

	[SerializeField]
	GameObject Player;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == Player)
		{
			if (CastleAPI.LoadMaxLevel() < 2)
			{
				CastleAPI.SaveMaxLevel(2);
			}

			SceneManager.LoadScene("LevelSelect");
		}
	}

}
