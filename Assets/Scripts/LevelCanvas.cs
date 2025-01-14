using UnityEngine;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour
{

	void Start()
	{
		int maxLevel = CastleAPI.LoadMaxLevel();

		for (int index = 1; index <= maxLevel; index++)
		{
			Button button = transform.GetChild(index).GetComponent<Button>();
			button.interactable = true;
		}
	}

}
