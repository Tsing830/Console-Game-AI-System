Shader "Unlit/shadowforLight"

{
   Properties {
		_mainColor ("亮部颜色" , color) = (1,1,1,1)
		_shadowColor ("阴影暗部颜色", Color) = (0.4, 0.4, 0.4, 1)
		_Opacity ("透明度" , Range(0.0 ,1.0 ) ) =1
		_range("范围", Range(-0.5,0.9)) =0.5
		_range1("内圈范围",Range(0,1.2)) = 0.5
		_range2("中间范围",Range(-1,1.2)) = 0.5
		_rangelight1("内圈亮度",Range(5,15)) = 8
		_rangelight2("中间亮度",Range(3,10)) = 3
		_rangelight3("外圈亮度", Range(0,5)) =1


		
		}
	SubShader {
		Tags { 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" "RenderType"="TransparentCutout"}
		
		Pass {
			// Pass for ambient light & first pixel light (directional light)
			Tags { "LightMode"="ForwardBase" }
			
            Blend One OneMinusSrcAlpha 

			CGPROGRAM
			
			// Apparently need to add this declaration 
			#pragma multi_compile_fwdbase	
			
			#pragma vertex vert
			#pragma fragment frag
			
			// Need these files to get built-in macros
			#include "Lighting.cginc"
			#include "AutoLight.cginc"
			
			uniform fixed4 _shadowColor;
			uniform fixed4 _mainColor;
			uniform sampler2D _mainTexture;
			uniform fixed _Opacity;
			
			
			struct a2v {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv0 	  :TEXCOORD3;
			};
			
			struct v2f {
				float4 pos : SV_POSITION;
				float3 nDirWS : TEXCOORD0;
				float3 worldPos : TEXCOORD1;
				float2 uv0 	  :TEXCOORD3;

				SHADOW_COORDS(2)
			};
			
			v2f vert(a2v v) {
			 	v2f o;
			 	o.pos = UnityObjectToClipPos(v.vertex);
			 	
			 	o.nDirWS = UnityObjectToWorldNormal(v.normal);
				
				o.uv0 = v.uv0; 

			 	o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
			 	
			 	// Pass shadow coordinates to pixel shader
			 	TRANSFER_SHADOW(o);
			 	
			 	return o;
			}
			
			fixed4 frag(v2f i) : SV_Target {

				float3 nDir = normalize( i.nDirWS);
				float3 lDir = _WorldSpaceLightPos0.xyz;
				
			 	fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos.xyz);
			 	fixed3 halfDir = normalize(lDir + viewDir);
			 	float  nDotl = dot(nDir , lDir);

				
				fixed shadow = SHADOW_ATTENUATION(i);
                shadow = floor(shadow);

				fixed3 finalRGB =(1-shadow)*_shadowColor.rgb + (shadow * _mainColor.rgb);

				return float4(finalRGB *_Opacity , _Opacity);

			}
			
			ENDCG
		}

		Pass { // Additional Pass
				// Pass for other pixel lights
				Tags { "LightMode" = "ForwardAdd" }

				Blend One One // 开启和设置了混合模式

				CGPROGRAM

				// Apparently need to add this declaration
				#pragma multi_compile_fwdadd_fullshadows

				#pragma vertex vert
				#pragma fragment frag

				#include "Lighting.cginc"
				#include "AutoLight.cginc"

				
				uniform fixed _Opacity;
				float _range;
				float _range1;
				float _range2;
				float _rangelight3;
				float _rangelight1;
				float _rangelight2;

				struct a2v {
					float4 vertex : POSITION;
					float3 normal : NORMAL;
                    float2 uv0 	  :TEXCOORD3;
				};

				struct v2f {
					float4 pos : SV_POSITION;
					float3 worldNormal : TEXCOORD0;
					float3 worldPos : TEXCOORD1;
                    float2 uv0 	  :TEXCOORD3;

                    SHADOW_COORDS(2)
                    
				};

				v2f vert(a2v v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);

					o.worldNormal = UnityObjectToWorldNormal(v.normal);

					o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                    o.uv0 = v.uv0; 


				    TRANSFER_SHADOW(o);



					return o;
				}

				fixed4 frag(v2f i) : SV_Target {
					fixed3 worldNormal = normalize(i.worldNormal);
					// 计算不同光源的方向
					#ifdef USING_DIRECTIONAL_LIGHT // 平行光
						fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz);
					#else
						fixed3 worldLightDir = normalize(_WorldSpaceLightPos0.xyz - i.worldPos.xyz); // 光源位置-顶点位置
					#endif

					fixed3 diffuse = _LightColor0.rgb  ;




 						fixed3 lightcolor = UNITY_LIGHTMODEL_AMBIENT.rgb;

                        UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);

                       fixed atten0 = floor(atten+0.897*(1+_range2*0.07 ));
                        fixed atten1 = floor(atten+0.9*(1+_range1*0.07 ) ) -atten0 ;
                        fixed atten2 = floor(atten+0.94 *(1+_range*0.07 ) ) - atten1-atten0;
                        
                        fixed3 finalRGB =(diffuse *(atten2 *_rangelight3 + atten1 *_rangelight2 + atten0*_rangelight1) );
					return fixed4( finalRGB *_Opacity, _Opacity); 
				}
				ENDCG
		}
	

	}
	FallBack "Transparent/Cutout/VertexLit"
}
