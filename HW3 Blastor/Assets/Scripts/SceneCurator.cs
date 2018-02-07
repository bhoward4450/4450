using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//holds transition actions for scenes
public class SceneCurator : MonoBehaviour {

	public void loadPlayArea1(){
		//Application.LoadLevel("PlayArea1");
		SceneManager.LoadScene ("PlayArea1", LoadSceneMode.Single);
	}

	public void loadMainMenu(){
		SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
	}

	public void closeApplication(){
		Application.Quit ();
	}

}
