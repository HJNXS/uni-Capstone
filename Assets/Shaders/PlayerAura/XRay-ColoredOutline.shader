﻿Shader "MyGame/XRay Shaders/ColoredFilled"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
	}

	SubShader
	{
		Stencil
		{
			Ref 0
			Comp NotEqual
		}

		Tags
		{
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
			"XRay" = "ColoredFilled"
		}

		ZWrite Off
		ZTest Always
		Blend One One

		Pass
		{

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			float4 _Color;
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
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				return _Color;
			}

			ENDCG
		}
	}
}
