using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public Transform mainMenu, levelSelect;

	public void LoadLevel(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}

	//changing panels on the main menu
	public void ChangePanel(Transform panel1, Transform panel2, bool clicked)
	{
		if (clicked == true)
		{
			panel1.gameObject.SetActive (false);
			panel2.gameObject.SetActive (clicked);
		} else {
			panel1.gameObject.SetActive (true);
			panel2.gameObject.SetActive (clicked);
		}
	}

	public void MainMenuToLevelSelect (bool clicked)
	{
		ChangePanel (mainMenu, levelSelect, clicked);
	}
	public void LevelSelectToMainMenu (bool clicked)
	{
		ChangePanel (levelSelect, mainMenu, clicked);
	}

}
	