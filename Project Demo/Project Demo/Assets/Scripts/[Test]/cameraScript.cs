using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {
	//Camera Movement
	public float speed = 3.0f;
	private float _speedH;
	private float _speedV;

	private float _yaw = 0.0f;
	private float _pitch = 0.0f;

	//RayCast
	private Ray _ray;
	private RaycastHit _rayCastHit;
	private float _rayLength;

	public static bool rayHit;
	public static Collider target;
	public static Vector3 targetLoc;

	// Use this for initialization
	void Start () {
		_rayLength = 2.0f;
		_speedH = speed;
		_speedV = speed;
	}

	// Update is called once per frame
	void Update () {
		//Camera Movement
		Cursor.visible = false;
		_yaw += _speedH * Input.GetAxis("Mouse X");
		_pitch -= _speedV * Input.GetAxis("Mouse Y");
		transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);

		//Raycast stuff
		_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		rayHit = Physics.Raycast (Camera.main.transform.position, GetComponent<Camera>().transform.forward * _rayLength, out _rayCastHit, _rayLength);
		Debug.DrawRay (Camera.main.transform.position, GetComponent<Camera> ().transform.forward,Color.green);
		if (rayHit) {
			target = _rayCastHit.collider;
			targetLoc = _rayCastHit.collider.transform.position;
		}



		//if(rayHit)
		//{        
		//	GManager.collidedObj = "stuff";
		//}
		//else
		//{
		//	GManager.collidedObj = null;
		//}
		//
		////Button Interaction
		//if (Input.GetMouseButtonDown(0) && GManager.collidedObj != null)
		//{
		//	GManager.collidedObj = rayCastHit.collider.name;
		//	GManager.select = true;
		//}
		//else if (Input.GetMouseButtonDown(0) && GManager.collidedObj == null)
		//{
		//	GManager.collidedObj = null;           
		//}
	}
}