using UnityEngine;
using System.Collections;


public class StateManager : MonoBehaviour {

	private static StateManager instance;

	/*untuk mengakses kelas gameController*/
	public GameController gameController;
		
	public static StateManager Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new
					GameObject("StateManager").AddComponent<StateManager>
						();
			}

			return instance;
		}

		/* find gameController yang mana yang 
		 * dipanggil saat start
		 */

	}

	public void OnApplicationQuit()
	{
		instance = null;
	}

	public void StartState()
	{
		Debug.Log ("New scene is being created...");

	}
}