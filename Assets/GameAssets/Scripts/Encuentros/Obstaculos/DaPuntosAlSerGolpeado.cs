using UnityEngine;
using System.Collections;

public class DaPuntosAlSerGolpeado : MonoBehaviour {

	public int puntos = 50;
	

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Bola")
		{
			Referencias.encuentro.SumarPuntos (puntos, this.transform.position);
		}
	}
}
