/*using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class GlowComposite : MonoBehaviour
{
	[Range (0, 10)]
	public float Intensity = 2;
	public Shader shader;
	private Material _compositeMat;

	void OnEnable()
	{
		if(_compositeMat==null)
			_compositeMat = new Material(shader);
    }

	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{ 
		if(_compositeMat==null)
			_compositeMat = new Material(shader);
		//_compositeMat.SetFloat("_Intensity", Intensity);
        Graphics.Blit(src, dst, _compositeMat, 0);
	}
}*/
