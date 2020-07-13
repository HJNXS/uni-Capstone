Shader "MyGame/Outline"
{
	Properties
	{
		_Color("Main Color", Color) = (1, 1, 1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline color", Color) = (0,0,0, 1)
		_OutlineWidth("Outline width", Range(1.0,5.0)) = 1.01
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent"}
		ZWrite Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _OutlineColor;
			float _OutlineWidth;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v.vertex.xyz *= _OutlineWidth; //expanding the vertex a bit upper to the normal
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			

			fixed4 frag (v2f i) : SV_Target
			{
				return _OutlineColor;
			}
			ENDCG
		}

		Pass
		{
			ZWrite On

			Material
			{
				Diffuse[_Color]
				Ambient[_Color]
			}

			Lighting On

			SetTexture[_MainTex]
			{
				ConstantColor[_Color]
			}

			SetTexture[_MainTex]
			{
				Combine previous * primary DOUBLE
			}
		}
	}
}
