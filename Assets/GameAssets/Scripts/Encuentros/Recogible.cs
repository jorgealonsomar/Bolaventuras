using UnityEngine;
using System.Collections;

public abstract class Recogible : MonoBehaviour {

	public AudioClip sonido;

	public GameObject prefabCartelPuntos;
	public int puntosOtorgados;


	void OnTriggerEnter (Collider col) {
		if (col.CompareTag ("Bola")) {
			Recogido ();
			OtorgarPuntos ();
			GameObject.FindObjectOfType<ReproductorDeSonidos> ().Reproducir (sonido);
			Destroy (transform.parent.gameObject);
		}
	}


	protected abstract void Recogido ();


	void OtorgarPuntos () {
		if (puntosOtorgados > 0) {
			GameObject nuevoCartelPuntos = Instantiate<GameObject> (prefabCartelPuntos);
			nuevoCartelPuntos.transform.position = new Vector3 (this.transform.position.x,
				this.transform.position.y + 4,
				this.transform.position.z);
			nuevoCartelPuntos.GetComponent<CartelPuntos> ().SetPoints (puntosOtorgados);

			Referencias.encuentro.SumarPuntos (puntosOtorgados);
		}
	}
}
