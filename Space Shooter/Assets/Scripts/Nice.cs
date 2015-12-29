using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nice : MonoBehaviour {

	public GameController gameController;
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
		Application.LoadLevel("Main");
		
		/* find gameController yang mana yang 
		 * dipanggil saat start
		 */
		GameObject tempObject = GameObject.FindWithTag("GameController");
		//if found ..
		if (tempObject)
		{
			gameController = tempObject.GetComponent<GameController>();
		}
		else
		{
			/* Throw notifications
			 * through the console
			 */
			Debug.Log ("Cannot Find 'GameController script!!");
		}


		gameController.nameText.text = stringToEdit;
		StateManager.Instance.StartState();


		
		
	}
}
