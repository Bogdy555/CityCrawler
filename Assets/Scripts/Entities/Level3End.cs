using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3End : MonoBehaviour
{

	[SerializeField]
	GameObject Player;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == Player)
		{
			if (CastleAPI.LoadMaxLevel() < 3)
			{
				CastleAPI.SaveMaxLevel(3);
			}

			SceneManager.LoadScene("LevelSelect");
		}
	}

}
