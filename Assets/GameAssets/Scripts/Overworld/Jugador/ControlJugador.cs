using UnityEngine;
using System.Collections;

public class ControlJugador : MonoBehaviour {

    public float speed = 45;

    Vector2 direccion;
    Jugador jugador;

	void Start () {

        jugador = GetComponent<Jugador>();
    }

	void Update () {
		if (Mision.estadoDelJuego == Mision.EstadoDelJuego.Libre) {

			//Direccion
			direccion = Vector2.zero;
			if (Input.GetKey (ConfiguracionTeclas.izquierda)) {
				direccion += Vector2.left;
			}
			if (Input.GetKey (ConfiguracionTeclas.derecha)) {

				direccion += Vector2.right;
			}
			if (Input.GetKey (ConfiguracionTeclas.arriba)) {

				direccion += Vector2.up;
			}
			if (Input.GetKey (ConfiguracionTeclas.abajo)) {
				direccion += Vector2.down;
			}

			jugador.AddForce (new Vector3 (direccion.x, 0, direccion.y) * Time.deltaTime * speed);

			//Salto
			if (Input.GetKey (ConfiguracionTeclas.flipperIzquierdo) && jugador.suelo) {
				jugador.Saltar ();
			}

		}
	}
}
