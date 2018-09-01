using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenNotInCamera : MonoBehaviour {
	// Update is called once per frame
	void OnBecameInvisible(){
		gameObject.SetActive(false);
	}
}
