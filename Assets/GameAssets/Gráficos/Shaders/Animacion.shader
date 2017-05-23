Shader "Animacion" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		
		_CeldasHorizontal("Cell Amount Width",float) = 0.0
		_CeldasVertical("Cell Amount Height",float) = 0.0
		_Speed("Speed", Range(0.01,32)) = 12
		_Color("Emision", Range(0,1)) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf SimpleLambert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		float _CeldasHorizontal;
		float _CeldasVertical;
				
		float _Speed;

		float _Color;

		void surf(Input IN, inout SurfaceOutput o) {
			float2 spriteUV = IN.uv_MainTex;
			float uvX = spriteUV.x / _CeldasHorizontal;
			float uvY = spriteUV.y / _CeldasVertical;

			float timeValx = fmod(_Time.y*_Speed, _CeldasHorizontal);
			timeValx = ceil(timeValx) - 1;
			float timeValy = fmod(_Time.y*_Speed, _CeldasHorizontal*_CeldasVertical);
			timeValy = ceil(timeValy / _CeldasHorizontal);

			spriteUV = float2(uvX + 1 / _CeldasHorizontal*timeValx - 1, uvY - 1 / _CeldasVertical*timeValy);


			fixed4 c = tex2D(_MainTex, spriteUV);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}

		half4 LightingSimpleLambert(SurfaceOutput s, half3 lightDir, half atten) {
			half NdotL = dot(s.Normal, lightDir);
			half4 c;
			c.rgb = s.Albedo * (_LightColor0.rgb * (NdotL * atten * 2)*(1-_Color)+1*_Color);
			c.a = s.Alpha;
			return c;
		}

		ENDCG
	} 
	FallBack "Diffuse"
}
