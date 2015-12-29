using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System.Collections;

public class GameController : MonoBehaviour {

	public Vector3 spawnValues;
	public GameObject hazard;
	public GameObject restartButton;
	public GameObject menuButton;

	public int hazardCount; //untuk wave of hazard, looping
	public float spawnWait; //wait time value for waving hazard attack
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText nameText;
	
	/*set to private
	 * karna ngga bisa diedit lewat Unity  */	
	private int score;
	private bool gameOver;
	private bool restart;
	private int highScore;


	void Start()
	{
		/*initiating score*/
		nameText.text = StateManager.Instance.NamaPemain;

		highScore=PlayerPrefs.GetInt("highScore");
		print(highScore);

		score = 0;
		gameOver = false;
		restart = false;

		restartText.text = "";
		gameOverText.text = "";
		
		UpdateScore();
		//to instantiate the hazard, calling itself
		StartCoroutine(SpawnWaves()); 

	}

	void Update()
	{
		if(restart)
		{
			if( Input.GetKeyDown (KeyCode.R))
			{
				//restart back to the laoded level ...
				Application.LoadLevel(Application.loadedLevel);
			}
		}

	}


	IEnumerator SpawnWaves(){

		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for(int i = 0; i < hazardCount; i++ ) //while true
			{
				Vector3 spawnPosition = new Vector3( Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				
				/* Buat coroutine untuk WaitForSeconds
				 * Kalau hanya Wait for seconds, 
				 * semua gamenya bisa berhenti.
				 * function coroutine : return IEnumerator
				 */
				yield return new WaitForSeconds(spawnWait);



				
			}
			yield return new WaitForSeconds(waveWait);

			/* Stop loop
			 * if it's game over
			 */
			if(gameOver)
			{
				if(score > highScore){
					print("New high score" + score);
				}

				highScore = score;
				PlayerPrefs.SetInt("highScore",highScore);
				restartText.text = "Press R to Restart";
				restart = true;
				break;
			}

		}


	}

	void UpdateScore()
	{
		scoreText.text = "Score : " + score;

	}

	public void AddScore (int newScoreValue){

		score += newScoreValue;
		UpdateScore();
	}

	public void GameOver()
	{
		gameOverText.text = "Anda kalah!!";
		gameOver = true;
	}
}
