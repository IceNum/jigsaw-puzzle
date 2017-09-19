Shader "ShaderGrayColored" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_LightUp ("Light Up", Range (0.01, 1)) = 0.5
		_Color ("Color", Range (0.01, 1)) = 0.15	
	}
	SubShader {
		Tags { "RenderType"="Opaque" "IgnoreProjector"="True"  }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float _Color;
		float _LightUp;
		

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);

			float r = c.r * 0.5 * (_LightUp*2);
			float g = c.g * 0.3 * (_LightUp*2);
			float b = c.b * 0.7 * (_LightUp*2);
			
            o.Albedo = dot(c.rgb, float3(r,g,b)) + (c.rgb * _Color);
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
