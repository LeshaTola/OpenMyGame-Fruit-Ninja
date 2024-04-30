Shader "Unlit/BlurShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
		_Spread("Blur Value", Float) = 0
		_Tint("_Tint", Color) = (1,1,1,1)
		_Transparency("_Transparency", Float) = 1
    }
    SubShader
    {
        Tags {  "RenderType"="Opaque" "RenderPipeline" = "UniversalPipeline"}

		Blend SrcAlpha OneMinusSrcAlpha

        LOD 100
			HLSLINCLUDE
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            #define E 2.71828f

		    sampler2D _MainTex;

		    CBUFFER_START(UnityPerMaterial)
			    float4 _MainTex_TexelSize;
			    float _Spread;
				float _Tint;
				float _Transparency;
		    CBUFFER_END

		    float gaussian(int x)
		    {
			    float sigmaSqu = _Spread * _Spread;
			    return (1 / sqrt(TWO_PI * sigmaSqu)) * pow(E, -(x * x) / (2 * sigmaSqu));
		    }

            struct appdata
			{
				float4 positionOS : Position;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 positionCS : SV_Position;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.positionCS = TransformObjectToHClip(v.positionOS.xyz);
				o.uv = v.uv;
				return o;
			}

			ENDHLSL

        Pass
        {
			HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            float4 frag (v2f i) : SV_Target
            {
                float4 col = float4(0.0, 0.0, 0.0, 0.0);
				float kernelSum = 0.0;

				int upper = ((_Spread - 1) / 2);
				int lower = -upper;

				for (int x = lower; x <= upper; ++x)
				{
					for (int y = lower; y <= upper; ++y)
					{
						kernelSum ++;
						float gauss = gaussian(y);

						float2 uv = i.uv + float2(_MainTex_TexelSize.x * x, _MainTex_TexelSize.y * y);
						col += gauss + tex2D(_MainTex, uv);
					}
				}

				col += 
				col /= kernelSum;
				col.a = _Transparency;

				float4 a = tex2D(_MainTex, i.uv);
				a.a = _Transparency;
                return a;
            }

			ENDHLSL
        }
    }
}
