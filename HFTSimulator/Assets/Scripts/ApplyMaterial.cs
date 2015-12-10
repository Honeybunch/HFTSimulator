using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ApplyMaterial : MonoBehaviour
{
    public Material material;
	
	// Postprocess the image onto the object
	void OnRenderImage (RenderTexture source, RenderTexture dest)
    {
        Graphics.Blit(source, dest, material);
    }
}
