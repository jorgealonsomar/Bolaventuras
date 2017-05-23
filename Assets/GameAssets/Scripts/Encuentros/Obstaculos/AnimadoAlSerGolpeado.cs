using UnityEngine;
using System.Collections;

public class AnimadoAlSerGolpeado : MonoBehaviour {


	Animator cmp_Animator;


	void Start () {
		cmp_Animator = GetComponent<Animator> ();
	}


	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Bola") {
			
			//Activar animacion
			cmp_Animator.SetTrigger ("Golpeado");
		
		}
	}
}
