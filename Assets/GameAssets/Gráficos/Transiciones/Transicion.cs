using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Transicion : MonoBehaviour {

    public Material material;
    public float corte = 0;

    void OnRenderImage(RenderTexture origen, RenderTexture destino)
    {
        if (corte > 0)
        {
            material.SetFloat("_Corte", corte);
            Graphics.Blit(origen, destino, material);
        }
        else Graphics.Blit(origen, destino);
    }
}