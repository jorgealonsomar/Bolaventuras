Shader "Hidden/Transición"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_RampTex("Rampa", 2D) = "grey" {}
		_Color("Color", Color) = (0,0,0,1)
		_Corte("Corte", Range(0,1)) = 0.5
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _RampTex;
			
			half4 _Color;
			half _Corte;

			fixed4 frag (v2f_img i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed cr = tex2D(_RampTex, i.uv).r;

				if (cr < _Corte * 1.1) {
					col = _Color;
				}

				return col;
			}

			ENDCG
		}
	}
}
