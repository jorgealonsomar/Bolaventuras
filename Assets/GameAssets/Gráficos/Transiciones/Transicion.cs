using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Transicion : MonoBehaviour {

    public Material material;

    void OnRenderImage(RenderTexture origen, RenderTexture destino)
    {
        Graphics.Blit(origen, destino, material);
    }
}
