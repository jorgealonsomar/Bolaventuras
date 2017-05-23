using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CartelPuntos : MonoBehaviour {

	public float fadeDuration;
	public float upVelocity;

	int points;

	Text cmp_Text;
	float alpha = 1;


	void Start () {
		cmp_Text = GetComponentInChildren<Text> ();

		cmp_Text.text = points.ToString ();
		Destroy (this.gameObject, fadeDuration);
	}
	

	void Update () {
		//Reducir el alpha (transparencia) del texto
		alpha -= Time.deltaTime / fadeDuration;

		Color textColor = cmp_Text.color;
		textColor.a = alpha;
		cmp_Text.color = textColor;

		//Mover hacia arriba
		transform.Translate (-transform.up * upVelocity * Time.deltaTime);
	}


	public void SetPoints (int puntos) {
		this.points = puntos;
	}
}
