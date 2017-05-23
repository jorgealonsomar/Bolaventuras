using UnityEngine;
using System.Collections;

public class CamaraALaAltura : MonoBehaviour {

	public GameObject foco;

	public float distanciaDeSeparacion;

	public Vector3 velocidad;

	public float tiempoDeSuavizado;


	void Start () {
		foco = FindObjectOfType<Bola> ().gameObject;
	}
	
	
	void FixedUpdate () {
		float posicionZ = Mathf.SmoothDamp (transform.position.z,
		                                    foco.transform.position.z - distanciaDeSeparacion,
		                                    ref velocidad.z,
		                                    tiempoDeSuavizado);

		transform.position = new Vector3 (transform.position.x,
		                                  transform.position.y,
		                                  posicionZ
		                                  );
	}
	
}
