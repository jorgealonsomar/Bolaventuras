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


	void Start () {
		estadoDelJuego = EstadoDelJuego.Libre;

		CalcularTiempoHastaProximoEncuentro ();
	}


	void Update () {
		if (maxTiempoHastaProximoEncuentro > 0) //Si maxTiempoHastaProximoEncuentro es cero (o negativo),
		{										//no se realiza ningun encuentro aleatorio.

			if (Input.GetKey (ConfiguracionTeclas.izquierda) ||
			    Input.GetKey (ConfiguracionTeclas.derecha) ||
			    Input.GetKey (ConfiguracionTeclas.arriba) ||
			    Input.GetKey (ConfiguracionTeclas.abajo)) {

				counter += Time.deltaTime;
			}

			if (counter >= tiempoHastaProximoEncuentro) {
				counter = 0;
				CalcularTiempoHastaProximoEncuentro ();
//				NuevoEncuentro ();
			}
		}
	}


	void CalcularTiempoHastaProximoEncuentro () {
		tiempoHastaProximoEncuentro = Random.Range (minTiempoHastaProximoEncuentro, maxTiempoHastaProximoEncuentro);
	}


	void NuevoEncuentro () {
		SceneManager.LoadScene (encuentros[0], LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(encuentros[0]));
        sala.SetActive(false);	
	}

    public void Reactivar()
    {
        sala.SetActive(true);
    }
}
