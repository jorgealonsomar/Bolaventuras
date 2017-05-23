using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class CSVLector
{

    static string original;
    static string[,] textos;

    public static string ObtenerTexto(int indice)
    {
        if (textos == null)
        {
            if (original == null)
            {
                original = Resources.Load<TextAsset>("TestText").text;
            }

            string patrónColumnas = "\",\""; //string patrónFilas = "\n";
            //Dividir en filas

            //original = (original[0] == '"') ? original.Remove(0, 1) : original;
            //original = (original[original.Length - 1] == '"') ? original.Remove(original.Length - 1, 1) : original;

            string[] filas = original.Split("\n"[0]);
            //filas = Regex.Split(original, patrónFilas);

            int cantidadColumnas = 0;

            for (int i = 0; i < filas.Length - 1; i++)
            {
                //Quitar las comillas
                filas[i] = filas[i][0] == '"' ? filas[i].Remove(0, 1) : filas[i];
                filas[i] = filas[i][filas[i].Length - 1] == '"' ? filas[i].Remove(filas[i].Length - 1) : filas[i];
                string[] columnas = Regex.Split(filas[i], patrónColumnas); // filas[i].Split("\",\""[0]);

                cantidadColumnas = Mathf.Max(cantidadColumnas, columnas.Length);
            }

            textos = new string[cantidadColumnas, filas.Length];
            for (int y = 0; y < filas.Length - 1; y++)
            {
                string[] columna = Regex.Split(filas[y], patrónColumnas); //filas[y].Split("\",\""[0]);                
                for (int x = 0; x < columna.Length; x++)
                {
                    textos[x, y] = columna[x];
                }
            }
        }
        return textos[0, indice];
    }
}