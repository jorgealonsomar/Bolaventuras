using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referencias : MonoBehaviour {

	public static GameManager gameManager;
	public static ReproductorDeSonidos reproductorDeSonidos;

	void Awake ()
	{
		gameManager = FindObjectOfType<GameManager> ();
		reproductorDeSonidos = FindObjectOfType<ReproductorDeSonidos> ();

	}

}
