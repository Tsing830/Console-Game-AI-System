Shader "Unlit/oneColor"
{
    Properties
    {
        _MainColor("颜色" , color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Tags{"LightMode"="ForwardBase"}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Lighting.cginc"
			#include "AutoLight.cginc"
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal :  NORMAL;
                float2 uv0    :TEXCOORD0;
            };

            struct v2f
            {
                float4 posOS : SV_POSITION;
                float4 posWS : TEXCOORD0;
                float3 nDirws: TEXCOORD1;
                float2 uv     :TEXCOORD2;
            };

            uniform float4 _MainColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.posOS = UnityObjectToClipPos( v.vertex );
                o.posWS = mul(unity_ObjectToWorld, v.vertex);
                o.nDirws = UnityObjectToWorldNormal(v.normal);
                o.uv = v.uv0;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                // apply fog
                return _MainColor;
            }
            ENDCG
        }
    }
    FallBack "Specular"
}
