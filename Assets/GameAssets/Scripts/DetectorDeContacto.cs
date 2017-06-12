using UnityEngine;
using System.Collections;

public class DetectorDeContacto : MonoBehaviour {

	public LayerMask capasConLasQuePuedeContactar;

	[SerializeField] int nContactos;


	void OnCollisionEnter (Collision collision)
	{
		if (capasConLasQuePuedeContactar == (capasConLasQuePuedeContactar | (1 << collision.collider.gameObject.layer)))
		{
			nContactos++;
		}
	}


	void OnCollisionExit (Collision collision)
	{
		if (capasConLasQuePuedeContactar == (capasConLasQuePuedeContactar | (1 << collision.collider.gameObject.layer)))
		{
			nContactos--;
		}
	}


	public bool HayContacto ()
	{
		return (nContactos > 0);
	}
}
