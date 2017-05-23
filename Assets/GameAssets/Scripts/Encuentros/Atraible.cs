using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atraible : MonoBehaviour
{
	public float potenciaDeAtraccion = 2.0f;

	Rigidbody cmp_Rigidbody;
	SphereCollider cmp_SphereCollider;

	float radioAtraibleMasRadioDeLaBola_Aux;
	float distanciaALaBola_Aux;
	float porcentajeDeCercania_Aux;

	Vector3 direccionAtraccion_Aux;

	float velocidad_Aux;

	void Awake ()
	{
		cmp_Rigidbody = GetComponentInParent<Rigidbody> ();
		cmp_SphereCollider = GetComponent<SphereCollider> ();
	}

	
	void OnTriggerStay (Collider col)
	{
		if (col.CompareTag ("Bola"))
		{
			radioAtraibleMasRadioDeLaBola_Aux = cmp_SphereCollider.radius + col.GetComponent<Bola> ().GetRadio ();
			distanciaALaBola_Aux = Vector3.Distance (this.transform.position, col.transform.position);
			porcentajeDeCercania_Aux = distanciaALaBola_Aux / radioAtraibleMasRadioDeLaBola_Aux;

			direccionAtraccion_Aux = col.transform.position - this.transform.position;
			velocidad_Aux = (potenciaDeAtraccion * (1 - porcentajeDeCercania_Aux));
			velocidad_Aux = Mathf.Pow (velocidad_Aux, 2);

			cmp_Rigidbody.AddForce (direccionAtraccion_Aux.normalized * velocidad_Aux, ForceMode.Force);
		}
	}

}
