using UnityEngine;
using System.Collections;

public class ReproductorDeSonidos : MonoBehaviour {

	AudioSource cmp_AudioSource;


	void Start () {
		cmp_AudioSource = GetComponent<AudioSource> ();
	}


	public void Reproducir (AudioClip sonido) {
		if (sonido != null) {
			cmp_AudioSource.PlayOneShot (sonido);
		} else {
			Debug.Log ("Se intentó reproducir un sonido null");
		}
	}
}
