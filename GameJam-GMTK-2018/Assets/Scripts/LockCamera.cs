using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class LockCamera : MonoBehaviour {
	public Transform objToLock;
	[HideInInspector]public FirstPersonController camera;
	//private Vector3 _lockedPos = Vector3.positiveInfinity;
	[Range(0,1000)]public float speed = 300f;

	private bool _preparingLookAt = false;

	public void OnEnable(){
		camera = GetComponent<FirstPersonController>();
		LockPosition();
	}
	public void LockPosition(){
		//_lockedPos =  //transform.rotation.eulerAngles; //CalculateCameraCenter(Camera.main);
	}

	public Vector3 CalculateCameraCenter(Camera cam){
 		return cam.ScreenToViewportPoint(new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, cam.transform.position.z));
	}

	public void UnlockPosition(){
		//_lockedPos = Vector3.positiveInfinity;
		objToLock = null;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		/*
		//Por convenção, sempre q não tiver posição para lockar a camera, ela estará em +infinito
		if(_lockedPos != Vector3.positiveInfinity){
			//transform.position = Vector3.Lerp(transform.position,_lockedPos,1.5f);
			transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles,_lockedPos, speed));
		}
		*/
		
		if(objToLock != null && !_preparingLookAt){
			Quaternion quat = Quaternion.LookRotation(objToLock.position - transform.position);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, speed * Time.deltaTime);
			camera.enabled = false;
			//StartCoroutine(PrepareLookAt());
		}

		if(Mathf.Max(Mathf.Abs(Input.GetAxis("Mouse X")), 
					Mathf.Abs(Input.GetAxis("Mouse Y"))) > 0.5){
			camera.enabled = true;
		}
		//transform.LookAt(objToLock);
	}

	IEnumerator PrepareLookAt(){
		_preparingLookAt = true;
		Debug.Log(10000/speed * Time.deltaTime);
		yield return new WaitForSeconds(10000/speed * Time.deltaTime);

		transform.LookAt(objToLock);
		_preparingLookAt = false;
	}
}
