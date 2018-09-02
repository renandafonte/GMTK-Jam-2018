using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {
	public Transform target;
	public float speedZoomIn = 15f;
	public float durationZoomIn = 3;
	public float speedZoomOut = 15f;
	public float durationZoomOut = 3;
    public float maxZoom = 30;

	private int step = 0; //0 é zoom in, 1 é mantém, 2 é zoom out

    private void Start()
    {
        //GameObject player = GameObject.Find("FPSController");
    }

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
        if(Camera.main.fieldOfView <= 60.0)
            Camera.main.fieldOfView += speedZoomIn;
	}
	
	void ZoomIn () {
		Debug.Log(Camera.main);
        if (Camera.main.fieldOfView >= maxZoom)
            Camera.main.fieldOfView -= speedZoomOut;	
	}

	IEnumerator ControlStep(){
		yield return new WaitForSeconds(durationZoomIn);
		step++;
		yield return new WaitUntil(() => step == 2);
		yield return new WaitForSeconds(durationZoomOut);
		this.enabled = false;
	}

    public void StartZoomOut(){
		step++;
	}
}
