using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour 
{

	public GameObject staffPanel;
	public GameObject levelPanel;
	bool isStaffPanel = false;
	bool isLevelPanel = false;

	public void OnClickedStartButton()
	{
		if (isStaffPanel == true) {
			isStaffPanel = false;
			staffPanel.SetActive (false);
		}
		if (isLevelPanel == true) {
			isLevelPanel = false;
			levelPanel.SetActive (false);
		}

		SceneManager.LoadScene ("Test1");

	}


	public void OnclickedStaffButton()
	{
		if (isLevelPanel == true) {
			isLevelPanel = false;
			levelPanel.SetActive (false);
		}
		isStaffPanel = true;
		staffPanel.SetActive (true);
	}

	public void OnClickedSelectButton()
	{
		if (isStaffPanel == true) {
			isStaffPanel = false;
			staffPanel.SetActive (false);
		}
		isLevelPanel = true;
		levelPanel.SetActive (true);
	}


}
