using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public Transform mainMenu, modeSelect;

	public void LoadLevel(string newGameLevel)
	{
		SceneManager.LoadScene (newGameLevel);
	}

	public void TryAgain()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
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

	public void MainMenuToModeSelect (bool clicked)
	{
		ChangePanel (mainMenu, modeSelect, clicked);
	}
	public void ModeSelectToMainMenu (bool clicked)
	{
		ChangePanel (modeSelect, mainMenu, clicked);
	}

}
	