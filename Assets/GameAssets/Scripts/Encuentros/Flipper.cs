using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour {

	HingeJoint cmp_HingeJoint;

	public float potencia;
	public KeyCode tecla = KeyCode.LeftControl;
	public bool flipperPrincipal;


	void Start () {
		cmp_HingeJoint = GetComponent<HingeJoint> ();
	}


	void Update () {
		if (Input.GetKeyDown (tecla)) {
			ActivarFlipper (true);
		} else if (Input.GetKeyUp (tecla)) {
			ActivarFlipper (false);
		}
	}


	void ActivarFlipper (bool activar) {
		JointSpring jointSpring = cmp_HingeJoint.spring;
		if (activar) {
			jointSpring.spring = potencia;
		} else {
			jointSpring.spring = 0;
		}
		cmp_HingeJoint.spring = jointSpring;
	}
}
