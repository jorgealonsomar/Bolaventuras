using UnityEngine;
using System.Collections;

public abstract class Desplegable : MonoBehaviour {

	public float escalaMinima = 1.0f;
	public float escalaMaxima = 1.0f;


	public abstract bool HayObstaculos ();
}
