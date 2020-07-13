Shader "Training/Properties" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_myRange("Example Range", Range(0,5)) = 1
		_myTex ("Albedo (RGB)", 2D) = "white" {}
		_myCube("Example Cube", CUBE) = ""{}
		_myFloat ("Example Float", Float) = 0.5
		_myVector("Example Vector", Vector) = (0.5,1,1,1)
		
	}
	SubShader {


		CGPROGRAM
		#pragma surface surf Lambert 

		struct Input {
			float2 uv_MainTex;
			float3 worldRefl;
		};

		fixed4 _Color;
		half _myRange;
		sampler2D _myTex;
		samplerCUBE _myCube;
		float _myFloat;
		float4 _myVector;

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			o.Albedo = tex2D(_myTex, IN.uv_MainTex).rgb;

		}
		ENDCG
	}
	FallBack "Diffuse"
}
