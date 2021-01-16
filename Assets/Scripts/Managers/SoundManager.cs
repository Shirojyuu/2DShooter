using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    private static AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
    public static void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);
    }
}
