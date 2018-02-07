using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour {
	public GameObject planet;
	public bool enableFinal{ get; set; }
	public void Start(){
		enableFinal = false;
	}
	public void Update (){
		if (enableFinal) {
			if (planet.transform.position.y > 2)
				planet.transform.Translate (0, -0.05f, 0);
			planet.transform.Rotate (0, 0, 0.01f);
		}
	}
}
