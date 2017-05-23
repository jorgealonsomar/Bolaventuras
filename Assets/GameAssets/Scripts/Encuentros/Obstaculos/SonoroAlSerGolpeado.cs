using UnityEngine;
using System.Collections;

public class SonoroAlSerGolpeado : MonoBehaviour {

	public AudioClip hitAudio;

	ReproductorDeSonidos reproductorDeSonidos;


	void Start () {
		reproductorDeSonidos = GameObject.FindObjectOfType<ReproductorDeSonidos> ();
	}

	
	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Bola") {

			//Activar audio
			reproductorDeSonidos.Reproducir (hitAudio);

		}
	}
}
