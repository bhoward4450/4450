﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public string playerName;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else if(instance != this) {
				Destroy(gameObject);
			}
		DontDestroyOnLoad(gameObject);
	}

	public void RestartLevel(float delay) {
		StartCoroutine(RestartLevelDelay(delay));
	}

	private IEnumerator RestartLevelDelay(float delay) {
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene("LevelSoy");
	}

	public List<PlayerTimeEntry> LoadPreviousTimes() { 
		// 1 
		try { 
			var scoresFile = Application.persistentDataPath +
			                 "/" + playerName +
			                 "_times.dat"; 
			using(var stream = File.Open(scoresFile, FileMode.Open)) {
				var bin = new BinaryFormatter();
				var times = (List<PlayerTimeEntry>)bin.Deserialize(stream);
				return times; 
			} 
		} 
		// 2 
		catch(IOException ex) {
			Debug.LogWarning("Couldn’t load previous times for: "
			+
			playerName +
			". Exception: "
			+ ex.Message);
			return new List<PlayerTimeEntry>();
		} 
	}

	public void SaveTime(decimal time) { 
		// 3 
		var times = LoadPreviousTimes();
		// 4 
		var newTime = 
			new PlayerTimeEntry();
		newTime.entryDate = DateTime.Now;
		newTime.time = time;
		// 5 
		var bFormatter = 
			new BinaryFormatter();
		var filePath = Application.persistentDataPath +
		               "/" + playerName +
		               "_times.dat"; 
		using(var file = File.Open(filePath, FileMode.Create)) {
			times.Add(newTime);
			bFormatter.Serialize(file, times);
		} 
	}

}
