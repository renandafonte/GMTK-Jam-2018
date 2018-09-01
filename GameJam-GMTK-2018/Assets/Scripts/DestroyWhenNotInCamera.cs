using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenNotInCamera : MonoBehaviour {
	void OnBecameInvisible(){
		gameObject.SetActive(false);
	}
}
