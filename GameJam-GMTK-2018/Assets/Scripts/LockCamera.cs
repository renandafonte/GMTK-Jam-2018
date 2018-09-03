using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class LockCamera : MonoBehaviour {
	public Transform objToLock;
	[HideInInspector]public FirstPersonController camera;
	[Range(0,1000)]public float speed = 300f;

	private bool movedMouse = false;

	private bool _preparingLookAt = false;

	public void OnEnable(){
		camera = GetComponent<FirstPersonController>();
	}

	public Vector3 CalculateCameraCenter(Camera cam){
 		return cam.ScreenToViewportPoint(new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, cam.transform.position.z));
	}

	public bool UnlockPosition(){
		objToLock = null;
		return movedMouse;
	}


	
	// Update is called once per frame
	void LateUpdate () {
		if(objToLock != null && !_preparingLookAt){
			Quaternion quat = Quaternion.LookRotation(objToLock.position - transform.position);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, speed * Time.deltaTime);
			camera.enabled = false;
		}

		if(Mathf.Max(Mathf.Abs(Input.GetAxis("Mouse X")), 
					Mathf.Abs(Input.GetAxis("Mouse Y"))) > 0.5){
			camera.enabled = true;
			movedMouse = true;
			UnlockPosition();
		}


	}
}
