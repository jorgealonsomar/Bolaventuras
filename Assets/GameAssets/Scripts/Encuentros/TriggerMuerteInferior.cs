using UnityEngine;
using System.Collections;

public class TriggerMuerteInferior : MonoBehaviour {


	void OnTriggerEnter (Collider col)
	{
		if (col.CompareTag ("Bola"))
		{
			col.GetComponent<Bola> ().SerDestruida ();
		}
	}
}
