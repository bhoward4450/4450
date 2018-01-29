using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour {
	public Sprite tileGliph, tileOpen;
	public bool isOpen;
	public int myId = 0, myNumber = 0;
	static public GameObject frameRef;

	private bool mouseIsOver = false;

	// Use this for initialization
	void Start () {
		CloseTile();
		FrameManager.tileArray[myId] = gameObject;
		myNumber = Random.Range(-9, 10);
	}
	void OnMouseEnter(){
		mouseIsOver = true;
	}

	void OnMouseExit(){
		mouseIsOver = false;
	}

	// Update is called once per frame
	void Update () {
		if (mouseIsOver) {
			if (Input.GetMouseButtonDown(0)) {
				if (isOpen)
					CloseTile();
				else
					OpenTile();
			}
			if (Input.GetMouseButtonDown(1)) {
				GetComponent<SpriteRenderer>().sprite = tileGliph;
				CloseTile();
				isOpen = false;
			}
		} 
	}

	public void OpenTile(){
		GetComponent<SpriteRenderer>().sprite = tileOpen;
		GetComponentInChildren<TextMesh>().text = "" + myNumber;
		isOpen = true;
		frameRef.GetComponent<FrameManager>().PlayTile(myId, myNumber);
	}

	public void ShowTile(){
		GetComponent<SpriteRenderer>().sprite = tileOpen;
		GetComponentInChildren<TextMesh>().text = "" + myNumber;
		isOpen = true;
	}

	public void CloseTile(){
		GetComponent<SpriteRenderer>().sprite = tileGliph;
		GetComponentInChildren<TextMesh>().text = "";
		isOpen = false;
	}

}
