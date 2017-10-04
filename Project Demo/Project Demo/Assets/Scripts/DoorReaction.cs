using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReaction : MonoBehaviour {
    private float spd;
    private Vector3 target;
    // Use this for initialization
    void Start () {
        spd = 5.0f;
        target = transform.position + new Vector3(0, 5, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if(GManager.collidedObj == "Button 2"|| GManager.select) {
            float step = spd * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            GManager.collidedObj = null;
            if (transform.position.y > target.y)
                GManager.select = false;

        }
	}
}
