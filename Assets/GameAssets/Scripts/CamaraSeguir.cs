using UnityEngine;
using System.Collections;

public class CamaraSeguir : MonoBehaviour {

	public GameObject foco;

	public float distanciaDeSeparacion;
    public float altura;

	public Vector3 velocidad;

	public float suavizadoVertical;


	void Start () {
	}
	
	
	void FixedUpdate () {
        float posicionX = Mathf.SmoothDamp(transform.position.x,
                                            foco.transform.position.x,
                                            ref velocidad.x,
                                            0);

        float posicionZ = Mathf.SmoothDamp (transform.position.z,
		                                    foco.transform.position.z - distanciaDeSeparacion,
		                                    ref velocidad.z,
		                                    0);

        float posicionY = Mathf.SmoothDamp(transform.position.y,
                                            foco.transform.position.y + altura,
                                            ref velocidad.y,
                                            suavizadoVertical);

        transform.position = new Vector3 (posicionX,
		                                  posicionY,
		                                  posicionZ
		                                  );
	}
	
}
