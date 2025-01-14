using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

	public void LevelSelectButton()
	{
		SceneManager.LoadScene("LevelSelect");
	}

	public void ExitButton()
	{
		Application.Quit();
	}

	public void CastleButton()
	{
		SceneManager.LoadScene("Castle");
	}

	public void VillageButton()
	{
		SceneManager.LoadScene("Village");
	}

	public void RuinsButton()
	{
		SceneManager.LoadScene("Ruins");
	}

	public void EndCastleButton()
	{
		SceneManager.LoadScene("EndCastle");
	}

	public void BackButton()
	{
		SceneManager.LoadScene("MainMenu");
	}

}
