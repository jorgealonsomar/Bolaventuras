using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CamaraAgitable : MonoBehaviour {

	public float duracionSacudida = 0.5f;


	public void Agitar() {
		this.transform.DOShakePosition (duracionSacudida);
	}
}
