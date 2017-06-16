using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class CSVLector
{

    static List<string[]> textos = new List<string[]>();

    public enum Idioma { Español = 1, Ingles = 2 };
    public static Idioma idioma = Idioma.Español;

    public static string ObtenerTexto(int indice)
    {
        if (textos.Count == 0)
        {
            Inicializar();
            if(textos.Count == 0)
            {
                Debug.LogWarning("Falta el archivo \"dialogos.csv\" en la carpeta Resources");
                return "Este mensaje aparece porque no se ha encontrado la hoja de cálculo";
            }
        }
        return textos[indice][(int)idioma];
    }

    public static LineaDeConversacion[] ObtenerLineasDeConversacion(int i)
    {
        Mathf.Clamp(--i, 0, int.MaxValue); //Para que el índice se corresponda con el número de fila en la tabla de cálculo

        List<LineaDeConversacion> lineasDeConversacion = new List<LineaDeConversacion>();

        while(i >= 0)
        {
            LineaDeConversacion nuevaLinea = new LineaDeConversacion();
            nuevaLinea.texto = ObtenerTexto(i);

            Dictionary<string, string> claves = new Dictionary<string, string>();
            string[] datos = textos[i][0].Split(","[0]);

            foreach (string dato in datos)
            {
                if(dato.IndexOf(":") >= 0) claves.Add(dato.Split(":"[0])[0].ToLower(), dato.Split(":"[0])[1].ToLower());
            }

            string foto;
            if (claves.TryGetValue("foto", out foto)) nuevaLinea.foto = Resources.Load<Sprite>("Fotos/" + foto);
            else if (lineasDeConversacion.Count > 0) nuevaLinea.foto = lineasDeConversacion[lineasDeConversacion.Count - 1].foto;

            string nombre;
            if (claves.TryGetValue("nombre", out nombre)) nuevaLinea.nombre = nombre;
            else if (lineasDeConversacion.Count > 0) nuevaLinea.nombre = lineasDeConversacion[lineasDeConversacion.Count - 1].nombre;

            lineasDeConversacion.Add(nuevaLinea);

            i = -1;
            string siguiente;
            if (claves.TryGetValue("siguiente", out siguiente)) i = EncontrarSiguiente(siguiente);
        }

        return lineasDeConversacion.ToArray();
    }

    static int EncontrarSiguiente(string siguiente)
    {
        int siguienteIndice = -1;
        if (int.TryParse(siguiente, out siguienteIndice)) siguienteIndice--; //Para que el índice se corresponda con el número de fila en la tabla de cálculo
        else
        {
            //???
        }        
        return siguienteIndice;
    }

    static void Inicializar()
    {
        string original = Resources.Load<TextAsset>("Conversaciones").text;
        string[] filas = Regex.Split(original, "\n");

        for (int y = 0; y < filas.Length; y++)
        {
            if (filas[y].Length > 0)
            {
                string fila = filas[y];

                fila = fila.Remove(0, 1);
                fila = fila.Remove(fila.LastIndexOf('\"'), fila.Length - fila.LastIndexOf('\"'));
                //fila = fila.Replace(@"\n", "\n");

                textos.Add(Regex.Split(fila, "\",\""));
            }
        }
    }
}