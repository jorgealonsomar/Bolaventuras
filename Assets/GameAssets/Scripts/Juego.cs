using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour {

    Mision mision;
    Encuentro encuentro;
    Camera camara;

    //SINGLETON-----------------------------------------------------------------------------------------
    //Hacer singleton y hacer que se genere automáticamente una instancia si ésta es llamada y no existe
    static Juego m_instancia;
    public static Juego instancia
    {
        get
        {
            if (m_instancia == null)
            {
                GameObject nuevaInstancia = new GameObject("Juego", new System.Type[]{typeof(Juego)}); //Nuevo objeto con el componente Juego
                return nuevaInstancia.GetComponent<Juego> ();
            }
            else return m_instancia;
        }
    }

	void Awake () {
        if (m_instancia == null)
        {
            DontDestroyOnLoad(gameObject);
            m_instancia = this;
        }
        else Destroy(this);
    //---------------------------------------------------------------------------------------------------

    }


//    void Update () {
//        if (camara == null || Camera.main != camara)
//        {
//            camara = Camera.main;
//        }
//	}

    public void SetMision (Mision nuevaMision)
    {
        if (mision != null) Destroy(mision);
        mision = nuevaMision;
        SceneManager.UnloadSceneAsync(mision.gameObject.scene);
        nuevaMision.transform.parent = transform;

        ActualizarCamara();
    }

    public void SetEncuentro (Encuentro nuevoEncuentro)
    {
		if (mision != null) mision.gameObject.SetActive (false);
        if (encuentro != null) Destroy(encuentro);
        encuentro = nuevoEncuentro;

        ActualizarCamara();
    }

    void ActualizarCamara ()
    {
        camara = Camera.main;
    }

    public void NuevoEncuentro (string encuentro)
    {
        StartCoroutine (TransicionDeEncuentro(encuentro));
    }

    IEnumerator TransicionDeEncuentro (string escena)
    {
        Transicion transicion = camara.GetComponent<Transicion>();
        if (transicion == null) camara.gameObject.AddComponent<Transicion>();
        while(transicion.corte < 1)
        {
            yield return new WaitForEndOfFrame();
            transicion.corte += Time.deltaTime * 2; //La transición ocurre en medio segundo           
        }

        SceneManager.LoadScene(escena);
    }

	public void VolverAlOverworld ()
	{
		if (mision != null) {
			mision.gameObject.SetActive (true);
			Destroy (encuentro.gameObject);
		} else {
			Debug.LogWarning ("No hay mision a la que volver (!)");
		}
	}
}
