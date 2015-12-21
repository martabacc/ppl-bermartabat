using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject playerExplosion;
	public GameObject explosion;

	/*untuk mengakses kelas gameController*/
	public GameController gameController;

	/*untuk add score*/
	public int scoreValue;

	void Start ()
	{
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
	}

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }

		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}

        Destroy(other.gameObject);
        Destroy(gameObject);

		/* add UpdateScore()
		 * dari file GameController
		 */
		gameController.AddScore( scoreValue );
    }
}
