using UnityEngine;
using System.Collections;

public class MovimientoCaracol : MonoBehaviour {

	public enum Estado {
		Parado,
		Avanzando,
		Girando
	}


	public DetectorDeContacto detectorDeContacto;

	Rigidbody rb;

	public Estado estado;

	float timer;

	public int velocidadAvance = 1;
	float tiempoParado = 2.0f;
	float tiempoGirando = 1.0f;

	float rotacionAAlcanzar;


	void Start () {
		rb = GetComponent<Rigidbody> ();
		estado = Estado.Avanzando;
	}


	void FixedUpdate () {
		timer += Time.deltaTime;

		if (estado == Estado.Parado && timer >= tiempoParado) {
			timer = 0.0f;
			EmpezarAGirar ();
		}

		else if (estado == Estado.Girando) {
			if (timer >= tiempoGirando) {
				timer = 0.0f;
				estado = Estado.Avanzando;
			} else {
				//TODO seguir interpolando rotacion
				transform.rotation = Quaternion.Euler ( new Vector3 (transform.rotation.x,
					Mathf.LerpAngle (transform.rotation.y, rotacionAAlcanzar, (timer / tiempoGirando)),
					transform.rotation.z) );
			}
		}

		else if (estado == Estado.Avanzando) {
			rb.velocity = (transform.forward * velocidadAvance);

			//Si choca
			if (detectorDeContacto.HayContacto ()) {
				timer = 0.0f;
				estado = Estado.Parado;
			}
		}


	}


	void EmpezarAGirar () {
		estado = Estado.Girando;

		rotacionAAlcanzar = Random.Range (0, 360.0f);
	}



}
