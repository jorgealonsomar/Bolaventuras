Shader "Custom/Terrain" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_Texture1 ("Tex1", 2D) = "white" {}
		_Texture2 ("Tex2", 2D) = "white" {}
		_Texture3 ("Tex3", 2D) = "white" {}
		_Scale ("Scale", Float) = 1
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _Texture1;
		sampler2D _Texture2;
		sampler2D _Texture3;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float4 vertex : COLOR;
		};

		half _Scale;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutput o) {
			float2 uvPosition = float2(IN.worldPos.x, IN.worldPos.z) *_Scale;

			fixed4 c1 = tex2D(_Texture1, uvPosition);
			fixed4 c2 = tex2D(_Texture2, uvPosition);
			fixed4 c3 = tex2D(_Texture3, uvPosition);

			fixed4 c = (c1 * IN.vertex.r + c2 * IN.vertex.g + c3 * IN.vertex.b);
			o.Albedo = c.rgb;

			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
