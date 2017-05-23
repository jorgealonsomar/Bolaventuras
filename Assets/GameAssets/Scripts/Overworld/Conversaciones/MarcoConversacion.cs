using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarcoConversacion : MonoBehaviour {

	public GameObject componentesVisibles;

	public Image foto;
	public Text nombre;
	public Text texto;

	public AudioClip sonidoTypewriter;

	public float velocidadTexto = 0.01f;

	ReproductorDeSonidos reproductorDeSonidos;

	Conversacion conversacionActual;
	int lineaActual;

	bool sePuedeAvanzarElTexto;


	void Start () {
		reproductorDeSonidos = GameObject.FindObjectOfType<ReproductorDeSonidos> ();
	}


	void Update () {
		if (Mision.estadoDelJuego == Mision.EstadoDelJuego.Conversando
			&& Input.GetKeyDown (ConfiguracionTeclas.avanzarConversacion)
			&& sePuedeAvanzarElTexto) {

			ReproducirSiguienteLinea ();
		}
	}


	public void NuevaConversacion (Conversacion conversacion) {
//		Debug.Log ("MarcoConversacion] Nueva conversacion");
		Mision.estadoDelJuego = Mision.EstadoDelJuego.Conversando;
		componentesVisibles.SetActive (true);

		conversacionActual = conversacion;
		lineaActual = -1;

		ReproducirSiguienteLinea ();
	}


	public void ReproducirSiguienteLinea () {
//		Debug.Log ("MarcoConversacion] Reproducir siguiente linea");
		lineaActual++;
		sePuedeAvanzarElTexto = false;

		if (lineaActual < (conversacionActual.lineasDeConversacion.Length)) {
			//Foto
			foto.sprite = conversacionActual.lineasDeConversacion [lineaActual].foto;
			//Nombre
			nombre.text = conversacionActual.lineasDeConversacion [lineaActual].nombre;
			//Texto
			StartCoroutine (EscribirElTexto (conversacionActual.lineasDeConversacion [lineaActual].texto));
		}
		else {
			Mision.estadoDelJuego = Mision.EstadoDelJuego.Libre;
			componentesVisibles.SetActive (false);
		}
	}


	IEnumerator EscribirElTexto (string textoAEscribir) {
		texto.text = "";
		bool sonar = false;

		for (int i = 0; i < textoAEscribir.Length; i++) {
			string caracter = textoAEscribir.Substring (i, 1);

			if (caracter == "$")
			{
				yield return new WaitUntil (() => Input.GetKeyDown (ConfiguracionTeclas.avanzarConversacion));
			}
			else
			{
				texto.text += caracter;

				sonar = !sonar;
				if (sonar) {
					reproductorDeSonidos.Reproducir (sonidoTypewriter);
				}

				yield return new WaitForSeconds (velocidadTexto);
			}
		}


		sePuedeAvanzarElTexto = true;
	}
}
