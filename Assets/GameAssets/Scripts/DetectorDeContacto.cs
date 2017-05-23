using UnityEngine;
using System.Collections;

public class DetectorDeContacto : MonoBehaviour {

	[SerializeField] int nContactos;


	void OnCollisionEnter (Collision collision) {
		Debug.Log ("Colision detectada");
		nContactos++;
	}


	void OnCollisionExit (Collision collision) {
		nContactos--;

	}


	public bool HayContacto () {
		return (nContactos > 0);
	}
}
