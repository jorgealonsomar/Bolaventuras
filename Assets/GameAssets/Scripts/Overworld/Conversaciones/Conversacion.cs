using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Conversacion {

	public LineaDeConversacion[] lineasDeConversacion;

	public Conversacion (int nConversacion) {
        lineasDeConversacion = CSVLector.ObtenerLineasDeConversacion(nConversacion);
        /* switch (nConversacion) {
            case 0:
                lineasDeConversacion = new LineaDeConversacion[3];

                for (int i = 0; i < lineasDeConversacion.Length; i++) {
                    lineasDeConversacion[i] = new LineaDeConversacion();
                }

                Sprite fotoCaracolRojo = Resources.Load<Sprite>("Fotos/CaracolRojo");
                lineasDeConversacion[0].foto = fotoCaracolRojo;
                lineasDeConversacion[0].nombre = "Caracol caraculo";
                lineasDeConversacion[0].texto = "Hola. Soy un caracol. Esto es una conversación de prueba.";
                lineasDeConversacion[1].foto = fotoCaracolRojo;
                lineasDeConversacion[1].nombre = "Caracol caraculo";
                lineasDeConversacion[1].texto = "Estamos probando el sistema de conversaciones. Tú y yo. Juntos.";
                lineasDeConversacion[2].foto = fotoCaracolRojo;
                lineasDeConversacion[2].nombre = "Caracol caraculo";
                lineasDeConversacion[2].texto = "Lo estamos haciendo, tío. ¡Estamos haciendo que OCURRA!";
                break;

            case 1:
                lineasDeConversacion = new LineaDeConversacion[2];

                for (int i = 0; i < lineasDeConversacion.Length; i++) {
                    lineasDeConversacion[i] = new LineaDeConversacion();
                }

                Sprite fotoAdolescente = Resources.Load<Sprite>("Fotos/Adolescente");
                lineasDeConversacion[0].foto = fotoAdolescente;
                lineasDeConversacion[0].nombre = "Adolescente";
                lineasDeConversacion[0].texto = "Si nos comiéramos a esos caracoles gigantes que han aparecido por la ciudad, podríamos acabar con el hambre en el mundo.";
                lineasDeConversacion[1].foto = fotoAdolescente;
                lineasDeConversacion[1].nombre = "Adolescente";
                lineasDeConversacion[1].texto = "Pero quién se come a un caracol.$ Iugh.";
                break;
        } */
	}
}

public class LineaDeConversacion
{
    public Sprite foto;
    public string nombre;
    public string texto;
}