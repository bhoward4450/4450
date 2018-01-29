using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager : MonoBehaviour {
	static public GameObject[] tileArray = new GameObject[8];
	private bool gameStarted = false; 
	private int countOpen, sum;
	private int[] chosenTile = new int[] {-1, -1, -1};
	private int timeLeftToClose = 100;

	// Use this for initialization
	void Start () {
		ClickTile.frameRef = gameObject;
		countOpen = 0;
		sum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameStarted){
			timeLeftToClose = 100;
			gameStarted = true;
			MakeSolution();
		} else {
			--timeLeftToClose;
			if (timeLeftToClose == 0) {
				CloseOpenTiles();
				timeLeftToClose = 100;
			}
		}
	}

	void CloseOpenTiles(){
		for (int i = 0; i < tileArray.Length; ++i){
			tileArray[i].GetComponent<ClickTile>().CloseTile();
		}
		sum = 0;
		countOpen = 0;
		timeLeftToClose = 100;
	}

	public void PlayTile(int id, int numTile){
		timeLeftToClose = 100;
		if (countOpen == 3){
			FrameManager.tileArray[id].GetComponent<ClickTile>().CloseTile();
			return;
		}
		if (countOpen < 3) {
			chosenTile[countOpen] = id;
			++countOpen;
			sum += numTile;
			if (countOpen == 3 && sum == 0){
				GameWon();
			}
		} else {
			CloseOpenTiles();
			countOpen = 0;
			sum = 0;
		}

		Debug.Log("Clicked tile: " + id + " with number: " + numTile);
	}

	void GameWon(){
		Debug.Log("GameWon");
		for(int i = 0; i < tileArray.Length; ++i){
			tileArray[i].GetComponent<ClickTile>().ShowTile();
		}
		sum = 0;
		countOpen = 0;
		timeLeftToClose = 100;
		gameStarted = false;
	}

	void MakeSolution(){
		int tile1Value = pickRandEqualZero(0,0,0),
			tile2Value = pickRandEqualZero(tile1Value, 0, 0),
			tile3Value = pickRandEqualZero(tile1Value, tile2Value, 0);
		tileArray[1].GetComponent<ClickTile>().myNumber = tile1Value;
		tileArray[2].GetComponent<ClickTile>().myNumber = tile2Value;
		tileArray[3].GetComponent<ClickTile>().myNumber = tile3Value;

		int num1 = tileArray[1].GetComponent<ClickTile>().myNumber;
		int num2 = tileArray[2].GetComponent<ClickTile>().myNumber;
		if (num1 + num2 > 9){
			num1 -= num1 + num2 - 9;
			tileArray[1].GetComponent<ClickTile>().myNumber = num1;
		}
		if (num1 + num2 < -9){
			num1 -= num2 + 9;
			tileArray[1].GetComponent<ClickTile>().myNumber = num1;
		}
		tileArray[3].GetComponent<ClickTile>().myNumber = -(num1 + num2);
	}

	int pickRandEqualZero(int num1, int num2, int num3){
		Debug.Log("Num1: " + num1 + " Num2: " + num2 +" Num3: " + num3);

		if (num1 == 0) {
			int check = Random.Range(-9, 9);
			if (check != 0)
				return check;
			return Random.Range(-3, -1) * Random.Range(1, 3);
		}
		if (num2 == 0){
			if (num1 > 0) {
				int check = Random.Range(-7, -1);
				if (Mathf.Abs(num1) - Mathf.Abs(check) == 0)
					return Random.Range(-7, -1);
				return check;
			}
			return Random.Range(1, 7);
		}
		return -(num1 + num2);
	}
}
