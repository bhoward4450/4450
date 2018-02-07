using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//var for the boundary of the play area. Determines max movement distances
	public int boundX;
	public KeyCode moveLeft, moveRight;
	//velocity at which the player moves
	public float speed;

	private Rigidbody2D rb2d;
	private GameManager gm;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		gm = GameObject.FindWithTag ("MainCamera").GetComponent<GameManager> ();
	}

	void FixedUpdate(){
		if (Input.GetKey(moveLeft)){
			rb2d.velocity = new Vector2 (-speed, 0);
		} else if (Input.GetKey(moveRight)){
			rb2d.velocity = new Vector2(speed, 0);
		}

		if (rb2d.transform.position.x > boundX)
			rb2d.transform.Translate (-boundX*2, 0, 0);
		if (rb2d.transform.position.x < -boundX)
			rb2d.transform.Translate (boundX*2, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.CompareTag("BadPickup")){
			gm.score -= 1;
			Destroy (col.gameObject);
			gm.spawnCollectable ();
		}
		if (col.gameObject.CompareTag("GoodPickup")){
			gm.score += 1;
			Destroy (col.gameObject);
			gm.spawnCollectable ();
		}
		if (col.gameObject.name == "BlastorPlanet")
			UnityEngine.SceneManagement.SceneManager.LoadScene (
				"Main Menu", UnityEngine.SceneManagement.LoadSceneMode.Single);
	}

}
