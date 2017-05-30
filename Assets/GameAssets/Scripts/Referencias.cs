using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referencias : MonoBehaviour {

	public static Juego gameManager;
	public static ReproductorDeSonidos reproductorDeSonidos;
	public static Encuentro encuentro;


	void Awake ()
	{
		gameManager = FindObjectOfType<Juego> ();
		reproductorDeSonidos = FindObjectOfType<ReproductorDeSonidos> ();
		encuentro = FindObjectOfType<Encuentro> ();
	}

}
