using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {
	public Transform target;
	public float speedZoomIn = 1.5f;
	public float durationZoomIn = 3;
	public float durationBreak = 2;
	public float speedZoomOut = 1.5f;
	public float durationZoomOut = 3;
    public float maxZoom = 30;

	private int step = 0; //0 é zoom in, 1 é mantém, 2 é zoom out

	void OnEnable(){
		StartCoroutine(ControlStep());
	}

	void Update(){
		switch(step){
			case 0:
                ZoomIn();
                break;
			case 2:
				ZoomOut();
                break;
		}
	}
	void ZoomOut () {
        if(Camera.current.fieldOfView <= 60.0)
            Camera.current.fieldOfView += speedZoomIn;
	}
	
	void ZoomIn () {
        if (Camera.current.fieldOfView >= maxZoom)
            Camera.current.fieldOfView -= speedZoomOut;	
	}

	IEnumerator ControlStep(){
		yield return new WaitForSeconds(durationZoomIn);
		step++;
		yield return new WaitForSeconds(durationBreak);
		step++;
		yield return new WaitForSeconds(durationZoomOut);
		this.enabled = false;
	}
}
