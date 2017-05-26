using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Mision : MonoBehaviour {

	public enum EstadoDelJuego {
		Libre,
		Conversando
	}

	public static EstadoDelJuego estadoDelJuego;

	public float minTiempoHastaProximoEncuentro;
	public float maxTiempoHastaProximoEncuentro;

    public string[] encuentros;
    public GameObject sala;

	[SerializeField] float counter;
	[SerializeField] float tiempoHastaProximoEncuentro;

    Jugador jugador;
    Juego juego;

	void Start () {
		estadoDelJuego = EstadoDelJuego.Libre;

		CalcularTiempoHastaProximoEncuentro ();

        juego = Juego.instancia;
        juego.SetMision(this);

        jugador = FindObjectOfType<Jugador>();
	}


	void Update () {
		if (maxTiempoHastaProximoEncuentro > 0) //Si maxTiempoHastaProximoEncuentro es cero (o negativo),
		{										//no se realiza ningun encuentro aleatorio.

			if ((Input.GetKey (ConfiguracionTeclas.izquierda) ||
			    Input.GetKey (ConfiguracionTeclas.derecha) ||
			    Input.GetKey (ConfiguracionTeclas.arriba) ||
			    Input.GetKey (ConfiguracionTeclas.abajo))) {

				counter += Time.deltaTime;
			}

			if (counter >= tiempoHastaProximoEncuentro && jugador.suelo) { //Sólo trigerear batalla cuando el jugador está en contacto con el suelo (para no comenzar la batalla en mitad de un salto)
				counter = 0;
				CalcularTiempoHastaProximoEncuentro ();
				juego.NuevoEncuentro(encuentros[Random.Range(0, encuentros.Length)]);
			}
		}
	}


	void CalcularTiempoHastaProximoEncuentro () {
		tiempoHastaProximoEncuentro = Random.Range (minTiempoHastaProximoEncuentro, maxTiempoHastaProximoEncuentro);
	}

    public void Reactivar()
    {
        sala.SetActive(true);
    }
}
