﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour {
	public Sprite tileGliph, tileOpen;
	public bool isOpen;
	public int myId = 0, myNumber = 0;

	// Use this for initialization
	void Start () {
		isOpen = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (isOpen)
				CloseTile();
			else
				OpenTile();
		}
		if (Input.GetMouseButtonDown(1)) {
			GetComponent<SpriteRenderer>().sprite = tileGliph;
			isOpen = false;
		}
	}

	public void OpenTile(){
		GetComponent<SpriteRenderer>().sprite = tileOpen;
		isOpen = true;
	}

	public void CloseTile(){
		GetComponent<SpriteRenderer>().sprite = tileGliph;
		isOpen = false;
	}

}