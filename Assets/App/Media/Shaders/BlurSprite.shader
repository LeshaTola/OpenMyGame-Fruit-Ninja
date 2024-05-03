Shader "Unlit/BlurSprite"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TintColor("Color", Color) = (1,1,1,1)
        _Blur("Blur Value", float) = 0
        _Step("Step", int) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #define E 2.71828f
            #define TWO_PI 3.14 * 2;
            
            sampler2D _MainTex;
            float4 _TintColor;
            float4 _MainTex_ST;
            float _Blur;
            int _Step;
            float4 _MainTex_TexelSize;

            float gaussian(int x)
		    {
			    float sigmaSqu = _Blur * _Blur;
			    return (1 / sqrt(3.14 * 2 *sigmaSqu)) * pow(E, -(x * x) / (2 * sigmaSqu));
		    }

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
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {

                float3 col = float3(0.0f, 0.0f, 0.0f);
				float gridSum = 0.0f;

				int upper = (( _Step - 1) / 2);
				int lower = -upper;

				for (int x = lower; x <= upper; ++x)
				{
					float gauss = gaussian(x);
					gridSum += gauss;
					float2 uv = i.uv + float2(_MainTex_TexelSize.x * x, _MainTex_TexelSize.y * x);
					col += gauss * tex2D(_MainTex, uv).xyz;
				}

				col /= gridSum; 

                return float4(col,1) * _TintColor;
            }
            ENDCG
        }
    }
}
