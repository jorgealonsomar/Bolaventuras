using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DesplegableCircular : Desplegable {

	public bool imprimirDebug;

	public LayerMask layerMaskSuelo;


	void Update () {
		if (Input.GetKeyDown (KeyCode.T)) {
			Debug.Log (HayObstaculos ());
		}
	}


	public override bool HayObstaculos () {
		float escala = transform.lossyScale.x;
		Collider[] obstaculos = Physics.OverlapSphere (this.transform.position, GetComponent<SphereCollider> ().radius * escala, ~layerMaskSuelo);

		List<Collider> collidersDelPadre = new List<Collider> ();
		collidersDelPadre.AddRange (GetComponentsInParent<Collider> ());
		collidersDelPadre.AddRange (transform.parent.GetComponentsInChildren<Collider> ());

		if (imprimirDebug) {
			string obstaculos_ToString = this.name + ": " + obstaculos.Length + " obstaculos (";
			foreach (Collider obstaculo in obstaculos) {
				obstaculos_ToString += obstaculo.name + " de " + obstaculo.transform.parent.name +  ",";
			}
			Debug.Log (obstaculos_ToString);
		}

		foreach (Collider obstaculo in obstaculos) {
			if (!collidersDelPadre.Contains (obstaculo)) {
				return true;
			}
		}

		return false;


	}
}
