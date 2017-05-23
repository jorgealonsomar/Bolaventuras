using UnityEngine;
using System.Collections;

public class Rompible : MonoBehaviour {
	
    public int hits = 3;
    public float fuerzaMinima = 10;
	public float fuerzaParaGolpeCritico = 60;

	public GameObject prefabMoneda;
	public int minMonedasSoltadas = 0;
	public int maxMonedasSoltadas = 0;

    Encuentro encuentro;

    void Start()
    {
        encuentro = GameObject.Find("Encuentro").GetComponent<Encuentro>();
    }
    void Update()
    {
		if (hits <= 0) Destruir ();
    }


    void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Bola") {
			float fuerzaDeImpacto = Vector3.Dot (collision.contacts [0].normal, collision.relativeVelocity);

			Debug.Log("Rompible] Fuerza del impacto: " + fuerzaDeImpacto);
			//Los impactos fuertes rondan entre 40 y 50. Un impacto normal gira entorno a los 25 y uno flojo no supera los 20

//			if (fuerzaDeImpacto >= fuerzaMinima) {
				if (fuerzaDeImpacto < fuerzaParaGolpeCritico) {
					hits -= 1;
				} else {
					hits -= 2;
              		Debug.Log(gameObject + " golpe critico!");
				FindObjectOfType<CamaraAgitable> ().Agitar ();
				}
//			}
		}
	}


	void Destruir () {
		int monedasSoltadas = Random.Range (minMonedasSoltadas, maxMonedasSoltadas);

		for (int i = 0; i < monedasSoltadas; i++) {
			GameObject moneda = Instantiate<GameObject> (prefabMoneda);
			moneda.transform.position = new Vector3 (this.transform.position.x,
				this.transform.position.y + 2.0f,
				this.transform.position.z);
			moneda.transform.Rotate (0, Random.Range (0, 360), Random.Range (0, 360));

			Rigidbody monedaRb = moneda.GetComponent<Rigidbody> ();
			monedaRb.AddForce (moneda.transform.forward * Random.Range (500, 1000));
			monedaRb.AddTorque (Random.Range (0, 100), Random.Range (0, 100), Random.Range (0, 100));
		}

        if (tag=="Enemigo")
        {
            encuentro.enemigos -= 1;
        }
		Destroy (gameObject);
	}
}