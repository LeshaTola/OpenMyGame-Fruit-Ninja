Shader "Unlit/AnotherBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Blur ("Blur", float) = 0
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
            #define TWO_PI 3.14*2
            
            Texture2D  _MainTex;
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;
            float _Blur;
            SamplerState sampler_MainTex;

		    float gaussian(int x)
		    {
			    float sigmaSqu = _Blur * _Blur;
			    return (1 / sqrt(TWO_PI * sigmaSqu)) * pow(E, -(x * x) / (2 * sigmaSqu));
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
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 col = float4(0.0, 0.0, 0.0, 0.0);
                float kernelSum = 0.0;
 
                int upper = ((_Blur - 1) / 2);
                int lower = -upper;
 
                for (int x = lower; x <= upper; ++x)
                {
                    for (int y = lower; y <= upper; ++y)
                    {
                        kernelSum ++;
 
                        float2 offset = float2(_MainTex_TexelSize.x * x, _MainTex_TexelSize.y * y);
                        col += _MainTex.Sample(sampler_MainTex, i.uv + offset);
                    }
                }
 
                col /= kernelSum;
                
                return col;//tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}
