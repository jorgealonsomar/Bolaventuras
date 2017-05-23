using UnityEngine;
using System.Collections;

public class Gravedad : MonoBehaviour {

	public float fuerzaGravedad = 20.0f;


	void Start () {
		Physics.gravity = this.transform.forward * fuerzaGravedad;
	}


}
