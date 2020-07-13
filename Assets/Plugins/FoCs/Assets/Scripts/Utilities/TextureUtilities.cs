using UnityEngine;

namespace ForestOfChaosLib.Utilities
{
	public static class TextureUtilities
	{
		public static Texture2D GetSolidTexture(Color col)
		{
			var tex = new Texture2D(2, 2);
			tex.SetPixels(new[] {col, col, col, col});
			tex.Apply();
			return tex;
		}
		public static Texture2D GetDevTexture(Color col,Color altColor)
		{
			var tex = new Texture2D(2, 2);
			tex.SetPixels(new[] {col, altColor, altColor, col});
			tex.Apply();
			return tex;
		}
	}
}