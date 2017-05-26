using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Encuentro : MonoBehaviour {

	public static Transform posicionInicial;

    public int enemigos;

//    Mision overworld;
    DesplegadorDeObstaculos[] desplegadores;
//	bool ready = false;

	static int coils;
	static int puntos;

    Juego juego;

	void Start () {
		Encuentro.posicionInicial = GameObject.FindGameObjectWithTag ("PosicionInicial").transform;

		ColocarBolaEnPosicionInicial ();

		enemigos = GameObject.FindGameObjectsWithTag ("Enemigo").Length;

        juego = Juego.instancia;
        juego.SetEncuentro(this);
	}



	void Update () {
		if (Input.GetKeyDown (KeyCode.K)) {
			ColocarBolaEnPosicionInicial ();
		}

		Debug.Log ("Coils: " + coils);
		Debug.Log ("Puntos: " + puntos);

//        if (!ready)
//        {
//            ready = true;
//            foreach (DesplegadorDeObstaculos desplegador in desplegadores)
//            {
//                if (!desplegador.ready) ready = false;
//            }
//        }

//        if (enemigos <= 0)
//        {
//            overworld.Reactivar();
//            SceneManager.UnloadScene(2);
//        }
	}


	public static void ColocarBolaEnPosicionInicial () {
		Bola bola = FindObjectOfType<Bola> ();
		bola.transform.position = posicionInicial.position;
		bola.transform.rotation = posicionInicial.rotation;
		bola.SetParametrosIniciales ();
	}


	public static void AddCoils (int nuevosCoils) {
		coils += nuevosCoils;
	}


	public static void SumarPuntos (int puntosASumar) {
		puntos += puntosASumar;
	}
}