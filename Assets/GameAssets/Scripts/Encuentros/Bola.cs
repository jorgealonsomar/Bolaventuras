using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

	public GameObject todoterreno;

	bool esperandoEmpezar;

	Rigidbody rb;

	KeyCode teclaInicio;


	void Start () {
		rb = GetComponent<Rigidbody> ();

		SetParametrosIniciales ();
	}


	/** Cambia los parametros tras haber sido situada en la posicion inicial
		(kinematica hasta que se pulse el flipper izquierdo, velocidad a cero...) */
	public void SetParametrosIniciales () {
		esperandoEmpezar = true;
		if (rb != null) { rb.isKinematic = true; }
	}


	void Update () {
		if (esperandoEmpezar && (  Input.GetKeyDown(ConfiguracionTeclas.flipperIzquierdo)
								|| Input.GetKeyDown(ConfiguracionTeclas.flipperDerecho)
								|| Input.GetKeyDown(ConfiguracionTeclas.moverFlippersALaIzquierda)
								|| Input.GetKeyDown(ConfiguracionTeclas.moverFlippersALaDerecha) ) ) {
			GetComponent<Rigidbody> ().isKinematic = false;
		}
	}

}
