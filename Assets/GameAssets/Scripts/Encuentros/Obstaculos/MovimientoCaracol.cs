using UnityEngine;
using System.Collections;

public class MovimientoCaracol : MonoBehaviour {

	public enum Estado { Parado, Avanzando, Girando }


	public DetectorDeContacto detectorDeContacto;

	Rigidbody rb;

	public Estado estado;

	float timer;

	public float velocidadAvance = 0.25f;
	public float velocidadMaxima = 2.0f;
	float tiempoParado = 2.0f;
	float tiempoGirando = 1.0f;

	public float velocidadRotacion = 100.0f;

//	float rotacionInicial;
//	float rotacionAAlcanzar;


	void Start () {
		rb = GetComponent<Rigidbody> ();
		estado = Estado.Avanzando;
	}


	void FixedUpdate () {
		timer += Time.deltaTime;

		if (estado == Estado.Parado && timer >= tiempoParado)
		{
			timer = 0.0f;
			EmpezarAGirar ();
		}

		else if (estado == Estado.Girando)
		{
			if (timer >= tiempoGirando) {
				timer = 0.0f;
				estado = Estado.Avanzando;
			} else {
				//TODO seguir interpolando rotacion
//				transform.rotation = Quaternion.Euler (
//					new Vector3 (transform.rotation.x,
//					Mathf.LerpAngle (rotacionInicial, rotacionAAlcanzar, (timer / tiempoGirando)),
//					transform.rotation.z)
//				);

				transform.Rotate (transform.up * velocidadRotacion * Time.fixedDeltaTime);
			}
		}

		else if (estado == Estado.Avanzando)
		{
			rb.velocity += (transform.forward * velocidadAvance * Time.fixedDeltaTime);

			if (rb.velocity.magnitude > velocidadMaxima)
			{
				rb.velocity = rb.velocity.normalized * velocidadMaxima;
			}

			//Si choca
			if (detectorDeContacto.HayContacto ()) {
				timer = 0.0f;
				estado = Estado.Parado;
			}
		}
	}


	void EmpezarAGirar () {
		estado = Estado.Girando;

		// Velocidad al azar entre 90 y 180 grados, hacia la izquierda o hacia la derecha
		velocidadRotacion = Random.Range (0.0f, 90.0f) + 90.0f;
		if (Random.Range (0, 1) == 0) velocidadRotacion = -velocidadRotacion;
	}



}
