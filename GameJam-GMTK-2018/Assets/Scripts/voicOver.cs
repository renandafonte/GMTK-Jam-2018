﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class voicOver : MonoBehaviour {

    private AudioSource audioVoice;

    private void Awake()
    {
        audioVoice = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioVoice.Play();
        }
    }
}