using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarcoConversacion : MonoBehaviour {

	public GameObject componentesVisibles;

	public Image foto;
	public Text nombre;
	public Text texto;

	public AudioClip sonidoTypewriter;

	public float velocidadTexto = 0.01f;

	ReproductorDeSonidos reproductorDeSonidos;

	Conversacion conversacionActual;
	int lineaActual;

	bool sePuedeAvanzarElTexto;

    bool bestFit;
    int fontSize;

	void Start () {
		reproductorDeSonidos = GameObject.FindObjectOfType<ReproductorDeSonidos> ();
        bestFit = texto.resizeTextForBestFit;
        fontSize = texto.fontSize;
	}


	void Update () {
		if (Mision.estadoDelJuego == Mision.EstadoDelJuego.Conversando
			&& Input.GetKeyDown (ConfiguracionTeclas.avanzarConversacion)
			&& sePuedeAvanzarElTexto) {

			ReproducirSiguienteLinea ();
		}
	}


	public void NuevaConversacion (Conversacion conversacion) {
//		Debug.Log ("MarcoConversacion] Nueva conversacion");
		Mision.estadoDelJuego = Mision.EstadoDelJuego.Conversando;
		componentesVisibles.SetActive (true);

		conversacionActual = conversacion;
		lineaActual = -1;

		ReproducirSiguienteLinea ();
	}


	public void ReproducirSiguienteLinea () {
//		Debug.Log ("MarcoConversacion] Reproducir siguiente linea");
		lineaActual++;
		sePuedeAvanzarElTexto = false;

		if (lineaActual < (conversacionActual.lineasDeConversacion.Length)) {
			//Foto
			foto.sprite = conversacionActual.lineasDeConversacion [lineaActual].foto;
			//Nombre
			nombre.text = conversacionActual.lineasDeConversacion [lineaActual].nombre;
			//Texto
			StartCoroutine (EscribirElTexto (conversacionActual.lineasDeConversacion [lineaActual].texto));
		}
		else {
			Mision.estadoDelJuego = Mision.EstadoDelJuego.Libre;
			componentesVisibles.SetActive (false);
		}
	}


	IEnumerator EscribirElTexto (string textoAEscribir) {
        //GENERAR LINEAS PARA EVITAR QUE EL TEXTO SALTE EN MITAD DE UNA PALABRA
        SetBestFit(true);
        texto.text = textoAEscribir;

        //Si no se hace esto el tamaño de la fuente generada con BestFit no coincide con el que debería tener no sé por qué ???
        texto.cachedTextGenerator.Invalidate();
        TextGenerationSettings tempSettings = texto.GetGenerationSettings(((RectTransform)texto.transform).rect.size);
        tempSettings.scaleFactor = 1;
        if (!texto.cachedTextGenerator.Populate(textoAEscribir, tempSettings))
            Debug.LogError("Failed to generate fit size");
        //--------

        string[] lineas = new string[texto.cachedTextGenerator.lineCount];
        for (int i = 0; i < lineas.Length; i++)
        {
            int indice = texto.cachedTextGenerator.lines[i].startCharIdx;
            if (i < lineas.Length - 1) {             
                int indiceFinal = texto.cachedTextGenerator.lines[i + 1].startCharIdx;
                lineas[i] = textoAEscribir.Substring(indice, indiceFinal - indice); 
            }
            else
            {
                lineas[i] = textoAEscribir.Substring(indice);
            }
            lineas[i] = lineas[i].Trim();
        }

        SetBestFit(false); //aquí se asigna el tamaño de la fuente generada al tamaño predeterminado de la fuente

        //ESCRIBIR EL TEXTO
        
        texto.text = "";        
        bool sonar = false;

        for (int linea = 0; linea < lineas.Length; linea++)
        {
            for (int i = 0; i < lineas[linea].Length; i++)
            {
                string caracter = lineas[linea].Substring(i, 1);

                if (caracter == "$")
                {
                    yield return new WaitUntil(() => Input.GetKeyDown(ConfiguracionTeclas.avanzarConversacion));
                }
                else
                {
                    texto.text += caracter;

                    sonar = !sonar;
                    if (sonar)
                    {
                        reproductorDeSonidos.Reproducir(sonidoTypewriter);
                    }

                    yield return new WaitForSeconds(velocidadTexto);
                }
            }
            texto.text += "\n";
        }

        sePuedeAvanzarElTexto = true;
	}

    void SetBestFit(bool setIt)
    {
        texto.fontSize = setIt ? fontSize : texto.cachedTextGenerator.fontSizeUsedForBestFit;
        texto.resizeTextForBestFit = setIt;        
    }
}
