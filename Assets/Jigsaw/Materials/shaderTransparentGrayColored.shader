Shader "TransparentGrayColored" {
    Properties {
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
		_Transparency ("Transparency", Range (0.01, 1)) = 0.65
		_Brightness ("Brightness", Range (0.01, 2)) = 1
		_Color ("Color", Range (0.01, 1)) = 0.15
    }

    SubShader {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert alpha

            sampler2D _MainTex;
			float _Transparency;
			float _Color;
			float _Brightness;

            struct Input {
                float2 uv_MainTex;
            };

            void surf (Input IN, inout SurfaceOutput o) {
                half4 c = tex2D(_MainTex, IN.uv_MainTex);
				
				float r = c.r * 0.5 * _Brightness;
				float g = c.g * 0.3 * _Brightness;
				float b = c.b * 0.7 * _Brightness;
				
                o.Albedo = dot(c.rgb, float3(r,g,b)) + (c.rgb * _Color);
                o.Alpha = 1-_Transparency;
            }

        ENDCG
    }

    Fallback "Transparent/Diffuse"
}
