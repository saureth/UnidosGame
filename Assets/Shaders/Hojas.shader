// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32815,y:32696,varname:node_4013,prsc:2|diff-7876-RGB,clip-7876-A,voffset-8508-OUT;n:type:ShaderForge.SFN_Tex2d,id:7876,x:32407,y:32757,ptovrint:False,ptlb:fondo,ptin:_fondo,varname:node_7876,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ValueProperty,id:7773,x:32332,y:33256,ptovrint:False,ptlb:intensidad,ptin:_intensidad,varname:node_7773,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:6448,x:32241,y:32893,ptovrint:False,ptlb:Ruido,ptin:_Ruido,varname:node_6448,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8240-OUT;n:type:ShaderForge.SFN_Multiply,id:8508,x:32543,y:33068,varname:node_8508,prsc:2|A-6448-RGB,B-7773-OUT;n:type:ShaderForge.SFN_TexCoord,id:6216,x:31847,y:32814,varname:node_6216,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:5638,x:31517,y:33235,varname:node_5638,prsc:2;n:type:ShaderForge.SFN_Add,id:8240,x:32057,y:32910,varname:node_8240,prsc:2|A-6216-UVOUT,B-3050-OUT;n:type:ShaderForge.SFN_Vector2,id:7813,x:31544,y:32970,varname:node_7813,prsc:2,v1:0,v2:1;n:type:ShaderForge.SFN_Vector2,id:7343,x:31680,y:33345,varname:node_7343,prsc:2,v1:1,v2:0;n:type:ShaderForge.SFN_Add,id:3050,x:32056,y:33208,varname:node_3050,prsc:2|A-9988-OUT,B-1411-OUT;n:type:ShaderForge.SFN_Multiply,id:9988,x:31695,y:33049,varname:node_9988,prsc:2|A-7813-OUT,B-15-OUT;n:type:ShaderForge.SFN_Multiply,id:1411,x:31870,y:33278,varname:node_1411,prsc:2|A-15-OUT,B-7343-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1372,x:31502,y:33151,ptovrint:False,ptlb:velocidad_viento,ptin:_velocidad_viento,varname:node_1372,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:15,x:31705,y:33186,varname:node_15,prsc:2|A-1372-OUT,B-5638-TSL;proporder:7876-7773-6448-1372;pass:END;sub:END;*/

Shader "Shader Forge/Hojas" {
    Properties {
        _fondo ("fondo", 2D) = "white" {}
        _intensidad ("intensidad", Float ) = 1
        _Ruido ("Ruido", 2D) = "white" {}
        _velocidad_viento ("velocidad_viento", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _fondo; uniform float4 _fondo_ST;
            uniform float _intensidad;
            uniform sampler2D _Ruido; uniform float4 _Ruido_ST;
            uniform float _velocidad_viento;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_5638 = _Time;
                float node_15 = (_velocidad_viento*node_5638.r);
                float2 node_8240 = (o.uv0+((float2(0,1)*node_15)+(node_15*float2(1,0))));
                float4 _Ruido_var = tex2Dlod(_Ruido,float4(TRANSFORM_TEX(node_8240, _Ruido),0.0,0));
                v.vertex.xyz += (_Ruido_var.rgb*_intensidad);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _fondo_var = tex2D(_fondo,TRANSFORM_TEX(i.uv0, _fondo));
                clip(_fondo_var.a - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = _fondo_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _fondo; uniform float4 _fondo_ST;
            uniform float _intensidad;
            uniform sampler2D _Ruido; uniform float4 _Ruido_ST;
            uniform float _velocidad_viento;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_5638 = _Time;
                float node_15 = (_velocidad_viento*node_5638.r);
                float2 node_8240 = (o.uv0+((float2(0,1)*node_15)+(node_15*float2(1,0))));
                float4 _Ruido_var = tex2Dlod(_Ruido,float4(TRANSFORM_TEX(node_8240, _Ruido),0.0,0));
                v.vertex.xyz += (_Ruido_var.rgb*_intensidad);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _fondo_var = tex2D(_fondo,TRANSFORM_TEX(i.uv0, _fondo));
                clip(_fondo_var.a - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = _fondo_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _fondo; uniform float4 _fondo_ST;
            uniform float _intensidad;
            uniform sampler2D _Ruido; uniform float4 _Ruido_ST;
            uniform float _velocidad_viento;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_5638 = _Time;
                float node_15 = (_velocidad_viento*node_5638.r);
                float2 node_8240 = (o.uv0+((float2(0,1)*node_15)+(node_15*float2(1,0))));
                float4 _Ruido_var = tex2Dlod(_Ruido,float4(TRANSFORM_TEX(node_8240, _Ruido),0.0,0));
                v.vertex.xyz += (_Ruido_var.rgb*_intensidad);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 _fondo_var = tex2D(_fondo,TRANSFORM_TEX(i.uv0, _fondo));
                clip(_fondo_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
