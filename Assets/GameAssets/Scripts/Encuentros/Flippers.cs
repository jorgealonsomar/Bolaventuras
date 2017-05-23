using UnityEngine;
using System.Collections;

//Quizás conviene buscar un nombre mejor para este script
public class Flippers : MonoBehaviour {

    Rigidbody rb;

    public float velocidad;

    //Asumo que los flippers siempre estarán en el centro
    public float limite;

    public KeyCode izquierda = KeyCode.LeftArrow;
    public KeyCode derecha = KeyCode.RightArrow;


    void Start () {
        rb = GetComponent<Rigidbody>();
	}


	void FixedUpdate () {

        if (Input.GetKey(izquierda))
        {
            Mover(-1);
		} else if (Input.GetKey(derecha))
        {
            Mover(1);
        }
    }


    void Mover(int direccion)  {
		rb.MovePosition (transform.position + new Vector3 (direccion * velocidad * Time.deltaTime, 0, 0));

		//Limitar
		if (transform.position.x >= limite && direccion > 0)
			rb.MovePosition (new Vector3 (limite, transform.position.y, transform.position.z));
		if (transform.position.x <= -limite && direccion < 0)
			rb.MovePosition (new Vector3 (-limite, transform.position.y, transform.position.z));
	}
}
