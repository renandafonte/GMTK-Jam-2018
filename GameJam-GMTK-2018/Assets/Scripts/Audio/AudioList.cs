using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour {
	public enum AudioType{
		BGM,
		SFX,
		Ambient
	}

	[System.Serializable]
	public class AudioInfo
	{
		public AudioSource source;
		public AudioType type; 
	}

	public List<AudioInfo> audioList;
}
