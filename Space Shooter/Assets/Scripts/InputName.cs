using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputName : MonoBehaviour {

	//public GameController gameController;
	public GameObject formInput;
	public string stringToEdit = "";
	public static string TextField;



	void OnGUI()
	{
		stringToEdit = GUI.TextField(new Rect(142, 280, 264, 35), stringToEdit, 30);


		if(GUI.Button (new Rect(191,330,160,30), "Ayo bermain!"))
		{
			StartGame();	
		}

		formInput.SetActive(true);
	}

	
	void StartGame()
	{
		print ("Starting Game..");

		DontDestroyOnLoad(StateManager.Instance);
		StateManager.Instance.NamaPemain = stringToEdit;

		Application.LoadLevel("Main");
		

		StateManager.Instance.StartState();


		
		
	}
}
