using UnityEngine;
using System.Collections;

public class Bola : MonoBehaviour {

	public GameObject todoterreno;

	bool esperandoEmpezar;

	KeyCode teclaInicio;

	Rigidbody cmp_Rigidbody;
	SphereCollider cmp_SphereCollider;


	void Start ()
	{
		cmp_Rigidbody = GetComponent<Rigidbody> ();
		cmp_SphereCollider = GetComponent<SphereCollider> ();

		SetParametrosIniciales ();
	}


	/** Cambia los parametros tras haber sido situada en la posicion inicial
		(kinematica hasta que se pulse el flipper izquierdo, velocidad a cero...) */
	public void SetParametrosIniciales ()
	{
		esperandoEmpezar = true;
		if (cmp_Rigidbody != null) { cmp_Rigidbody.isKinematic = true; }
	}


	public float GetRadio ()
	{
		return cmp_SphereCollider.radius;
	}


	void Update ()
	{
		if (esperandoEmpezar && (  Input.GetKeyDown(ConfiguracionTeclas.flipperIzquierdo)
								|| Input.GetKeyDown(ConfiguracionTeclas.flipperDerecho)
								|| Input.GetKeyDown(ConfiguracionTeclas.moverFlippersALaIzquierda)
								|| Input.GetKeyDown(ConfiguracionTeclas.moverFlippersALaDerecha) ) )
		{
			GetComponent<Rigidbody> ().isKinematic = false;
		}
	}


	public void SerDestruida ()
	{
		Referencias.encuentro.BolaDestruida (this);
	}

}
