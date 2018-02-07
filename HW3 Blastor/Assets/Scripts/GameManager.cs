using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject player;
	public GameObject goodPickup, badPickup;
	public int initialCollectables, winScore;
	public int score { get; set;}

	private Text scoreText;
	private bool gameOver = false;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("textScore").GetComponent<Text>();
		score = 0;
		scoreText.text += score.ToString();
		for (int i = 0; i < initialCollectables; ++i)
			spawnCollectable ();
	}

	void Update(){
		scoreText.text = "Score: " + score;
		if (score >= winScore){
			//winning conditions
			gameWon();
		} else if (score < 0){
			//losing conditions
			gameOver = true;
			SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
		}
	}

	private void gameWon(){
		gameOver = true;
		Text winText1 = GameObject.Find ("WinText1").GetComponent<Text>();
		winText1.text = "CONGRATULATIONS YOU WON!";

		Text winText2 = GameObject.Find ("WinText2").GetComponent<Text>();
		winText2.text = "Crash into the planet to play again";

		GameObject planet = GameObject.Find("BlastorPlanet");
		if (planet.transform.position.y > 3)
			planet.GetComponent<PlanetRotator> ().enableFinal = true;
	}

	public void spawnCollectable(){
		if (!gameOver) {
			int rand = Random.Range (0, 2);
			if (rand == 0) {
				Instantiate (goodPickup, new Vector3 (1, 4, 0), Quaternion.identity);
			} else if (rand == 1) {
				Instantiate (badPickup, new Vector3 (-2, 4, 0), Quaternion.identity);
			}
		}
	}

}
