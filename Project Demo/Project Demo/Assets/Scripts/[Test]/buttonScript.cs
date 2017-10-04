using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour {
	public GameObject highlightBubble;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraScript.rayHit) {
			highlightBubble.transform.position = cameraScript.targetLoc;
		}
			
	}
}
