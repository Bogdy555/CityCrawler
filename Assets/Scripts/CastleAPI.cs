using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleAPI : MonoBehaviour
{

	static public int LoadMaxLevel()
	{
		if (!File.Exists("Save"))
		{
			return 0;
		}

		return int.Parse(File.ReadAllText("Save"));
	}

	static public void SaveMaxLevel(int maxLevel)
	{
		File.WriteAllText("Save", maxLevel.ToString());
	}

}
