using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour {



	void OnGUI()
	{
		if(GUI.Button (new Rect(191,290,160,30), "Start Game"))
		{
			StartGame();	
		}
	}

	void StartGame()
	{
		print ("Starting Game..");
		DontDestroyOnLoad(StateManager.Instance);
		Application.LoadLevel("InputName");
		StateManager.Instance.StartState();


	}
}
