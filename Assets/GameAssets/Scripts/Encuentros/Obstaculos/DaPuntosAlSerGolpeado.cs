using UnityEngine;
using System.Collections;

public class DaPuntosAlSerGolpeado : MonoBehaviour {

	public GameObject prefabCartelPuntos;

	public int puntos = 50;
	

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Bola") {
			GameObject nuevoCartelPuntos = Instantiate<GameObject> (prefabCartelPuntos);
			nuevoCartelPuntos.transform.position = new Vector3 (this.transform.position.x,
																this.transform.position.y + 4,
																this.transform.position.z);
			nuevoCartelPuntos.GetComponent<CartelPuntos> ().SetPoints (puntos);

			Encuentro.SumarPuntos (puntos);
		}
	}
}
