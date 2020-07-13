Shader "Training/PackedPractice" {
	Properties {
		_myColour ("Example Colour", Color) = (1,1,1,1)
		
	}
	SubShader {

		CGPROGRAM
		#pragma surface surf Lambert
		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _myColour;
		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _myColour.rgb;
			o.Alpha = _myColour.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
