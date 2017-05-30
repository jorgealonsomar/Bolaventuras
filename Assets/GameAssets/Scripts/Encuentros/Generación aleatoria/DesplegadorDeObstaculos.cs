using UnityEngine;
using System.Collections;

[System.Serializable]
public class Obstaculo
{
    public GameObject tipo;
    public int cantidad;
}

public class DesplegadorDeObstaculos : MonoBehaviour
{

    public Obstaculo[] obstaculosADesplegar;

    BoxCollider colliderZona;

    public bool ready = false;

    void Start ()
    {
        colliderZona = GetComponentInChildren<BoxCollider> ();

        DesplegarObstaculos();
        ready = true;
    }


    void Update()
    {
        //		Debug.DrawLine (colliderZona.bounds.min, colliderZona.bounds.max);
    }


    public void DesplegarObstaculos()
    {
        foreach (Obstaculo obstaculo in obstaculosADesplegar)
        {
            while (obstaculo.cantidad > 0)
            {
                GameObject nuevoObstaculo = Instantiate<GameObject>(obstaculo.tipo);
                Desplegable desplegable = nuevoObstaculo.GetComponentInChildren<Desplegable>();

				nuevoObstaculo.transform.localScale = nuevoObstaculo.transform.localScale *
					Random.Range (desplegable.escalaMinima, desplegable.escalaMaxima);

                int nIntentos = 0;
                bool colocado = false;
                while (!colocado)
                {

                    nuevoObstaculo.transform.position = CoordenadaAleatoriaDentroDelAreaDeDespliegue();
                    if (!desplegable.HayObstaculos())
                    {
						
                        colocado = true;
                    }

                    nIntentos++;
                    if (nIntentos >= 1000)
                    {
                        break;
                    }
                }

                if (!colocado)
                {
                    Destroy(nuevoObstaculo);
                }

                obstaculo.cantidad--;
            }
        }
    }


    Vector3 CoordenadaAleatoriaDentroDelAreaDeDespliegue()
    {
        float posX = Random.Range(colliderZona.bounds.min.x, colliderZona.bounds.max.x);
        float posZ = Random.Range(colliderZona.bounds.min.z, colliderZona.bounds.max.z);

        return new Vector3(posX, 0, posZ);
    }

}
