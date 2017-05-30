using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Encuentro : MonoBehaviour {

	public static Transform posicionInicial;

	int _nEnemigos;
    public int NEnemigos {
		get { return _nEnemigos; }
		set {
			_nEnemigos = value;
			if (value == 0) HaSidoGanado = true;
		}
	}

	public GameObject prefabCartelPuntos;
	public GameObject prefabCartelMonedas;

	Text textMonedas; 
	Text textPuntos; 

	bool _haSidoGanado = false;
	bool HaSidoGanado {
		get { return _haSidoGanado; }
		set {
			_haSidoGanado = value;
			//TODO: Cambiar musica
		}
	}

	int coils;
	int puntos;

    Juego juego;


	void Awake ()
	{
		Encuentro.posicionInicial = GameObject.FindGameObjectWithTag ("PosicionInicial").transform;

		textMonedas = GameObject.Find ("Canvas Encuentro/Fondo/Coins Text").GetComponent<Text> ();
		textPuntos = GameObject.Find ("Canvas Encuentro/Fondo/Points Text").GetComponent<Text> ();
	}


	void Start ()
	{
		ColocarBolaEnPosicionInicial ();

		NEnemigos = GameObject.FindGameObjectsWithTag ("Enemigo").Length;

        juego = Juego.instancia;
        juego.SetEncuentro(this);
	}



	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.K) && Application.isEditor)
		{
			ColocarBolaEnPosicionInicial ();
		}
	}


	public void ColocarBolaEnPosicionInicial ()
	{
		Bola bola = FindObjectOfType<Bola> ();
		bola.transform.position = posicionInicial.position;
		bola.transform.rotation = posicionInicial.rotation;
		bola.SetParametrosIniciales ();
	}


	public void AddCoils (int nuevosCoils, Vector3? posicionCartel = null)
	{
		coils += nuevosCoils;
		textMonedas.text = " x " + coils;

		if (posicionCartel != null)
		{
			GameObject nuevoCartelMonedas = Instantiate<GameObject> (prefabCartelMonedas);
			nuevoCartelMonedas.transform.position = ((Vector3)posicionCartel) + (Vector3.up * 4.0f);
			nuevoCartelMonedas.GetComponent<CartelPuntos> ().SetPoints (nuevosCoils);
		}
	}


	public void SumarPuntos (int puntosASumar, Vector3? posicionCartel = null)
	{
		puntos += puntosASumar;
		textPuntos.text = "Puntos: " + puntos;

		if (posicionCartel != null)
		{
			GameObject nuevoCartelPuntos = Instantiate<GameObject> (prefabCartelPuntos);
			nuevoCartelPuntos.transform.position = ((Vector3)posicionCartel) + (Vector3.up * 4.0f);
			nuevoCartelPuntos.GetComponent<CartelPuntos> ().SetPoints (puntosASumar);
		}
	}


	public void BolaDestruida (Bola bola)
	{
		if (HaSidoGanado)
		{
			juego.VolverAlOverworld ();
		}
		else
		{
			ColocarBolaEnPosicionInicial ();
		}
	}
}