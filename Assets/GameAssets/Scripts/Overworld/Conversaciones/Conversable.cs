using UnityEngine;
using System.Collections;

public class Conversable : MonoBehaviour {

	public int nConversacion;
	Conversacion conversacion;

	MarcoConversacion cmp_MarcoConversacion;


	void Start ()
	{
		cmp_MarcoConversacion = GameObject.FindObjectOfType<MarcoConversacion> ();

		//Borrar despues:
		conversacion = new Conversacion (nConversacion);
	}


	void OnTriggerStay (Collider col)
	{
		if (col.tag == "Bola" && Input.GetKeyDown (ConfiguracionTeclas.flipperDerecho)
		    && Mision.estadoDelJuego == Mision.EstadoDelJuego.Libre) {

			transform.parent.LookAt (new Vector3 (col.transform.position.x, this.transform.position.y, col.transform.position.z));

			cmp_MarcoConversacion.NuevaConversacion (conversacion);
		}
	}
}
