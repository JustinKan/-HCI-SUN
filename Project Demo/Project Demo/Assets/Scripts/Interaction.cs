using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {
    //Camera Movement
    public float speed = 3.0f;
    private float speedH;
    private float speedV;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //RayCast
    private Ray ray;
	private RaycastHit rayCastHit;
	private float rayLength;

	// Use this for initialization
	void Start () {
		rayLength = 4.0f;
        speedH = speed;
        speedV = speed;
	}
	
	// Update is called once per frame
	void Update () {
        //Camera Movement
        Cursor.visible = false;
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
        //Raycast stuff
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(Camera.main.transform.position, GetComponent<Camera>().transform.forward * rayLength, out rayCastHit, rayLength))
        {        
            GManager.collidedObj = "stuff";
        }
        else
        {
            GManager.collidedObj = null;
        }

        //Button Interaction
        if (Input.GetMouseButtonDown(0) && GManager.collidedObj != null)
        {
            GManager.collidedObj = rayCastHit.collider.name;
            GManager.select = true;
        }
        else if (Input.GetMouseButtonDown(0) && GManager.collidedObj == null)
        {
            GManager.collidedObj = null;           
        }
    }
}

