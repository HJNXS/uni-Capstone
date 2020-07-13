Shader "Training/FirstShader" {
	Properties
	{
		_myColour("Example Colour", Color) = (1,1,1,1)
		_myAlbedo("Albedo Colour", Color) = (1,1,1,1)
		_myNormal("Normal Colour", Color) = (1,1,1,1)
	}

	SubShader
	{
		CGPROGRAM
			#pragma surface surf Lambert
			struct Input {
				float2 uvMainTex;
			};

			fixed4 _myColour;
			fixed4 _myAlbedo;
			fixed4 _myNormal;
			void surf(Input IN, inout SurfaceOutput o)
			{
				o.Albedo = _myAlbedo.rgb;
				o.Emission = _myColour.rgb;
				o.Normal = _myNormal.rgb;
			}
		ENDCG
	}
	FallBack "Diffuse"
}
