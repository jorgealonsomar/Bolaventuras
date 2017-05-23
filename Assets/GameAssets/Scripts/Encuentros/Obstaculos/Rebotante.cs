using UnityEngine;
using System;
using System.Collections;

public class Rebotante : MonoBehaviour {

	public float fuerza = 0.5f;


	void Start () {
        fuerza *= 1000;
	}


	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Bola") {

			Vector3 normalDeLaColision = -collision.contacts [0].normal;

			//Dibujar la normal en el editor
			//Debug.DrawRay (this.transform.position, normalDeLaColision * 10, Color.red, 5.0f);

			//Lanzar la bola en la direccion de la normal
			collision.gameObject.GetComponent<Rigidbody> ().AddForce (normalDeLaColision * fuerza, ForceMode.Impulse);
		}
	}

}
