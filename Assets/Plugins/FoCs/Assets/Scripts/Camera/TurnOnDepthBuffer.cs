using UnityEngine;
using UCamera = UnityEngine.Camera;

namespace ForestOfChaosLib.Camera
{
	public class TurnOnDepthBuffer: MonoBehaviour
	{
		public void Start()
		{
			UCamera.main.depthTextureMode = DepthTextureMode.Depth;
		}
	}
}
