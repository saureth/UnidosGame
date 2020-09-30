// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:17,x:32740,y:32565,varname:node_17,prsc:2|emission-2847-OUT,voffset-2691-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:1037,x:31770,y:33032,varname:node_1037,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:3042,x:31628,y:32893,ptovrint:False,ptlb:fuerza,ptin:_fuerza,varname:node_3042,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:9622,x:32293,y:32899,varname:node_9622,prsc:2|A-3042-OUT,B-2164-OUT;n:type:ShaderForge.SFN_Multiply,id:2691,x:32529,y:32944,varname:node_2691,prsc:2|A-9622-OUT,B-7339-UVOUT;n:type:ShaderForge.SFN_Sin,id:2164,x:32117,y:32952,varname:node_2164,prsc:2|IN-1902-OUT;n:type:ShaderForge.SFN_TexCoord,id:7339,x:32267,y:33046,varname:node_7339,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ValueProperty,id:5081,x:31794,y:32945,ptovrint:False,ptlb:Frecuencia,ptin:_Frecuencia,varname:node_5081,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:1902,x:31960,y:32973,varname:node_1902,prsc:2|A-5081-OUT,B-1037-Y;n:type:ShaderForge.SFN_Tex2d,id:1193,x:32083,y:32249,ptovrint:False,ptlb:Fondo,ptin:_Fondo,varname:node_1193,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_NormalVector,id:2800,x:31667,y:32632,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:1562,x:31649,y:32510,varname:node_1562,prsc:2;n:type:ShaderForge.SFN_Dot,id:3739,x:31853,y:32569,varname:node_3739,prsc:2,dt:0|A-1562-OUT,B-2800-OUT;n:type:ShaderForge.SFN_Step,id:4902,x:32057,y:32468,varname:node_4902,prsc:2|A-9598-OUT,B-3739-OUT;n:type:ShaderForge.SFN_Slider,id:9598,x:31570,y:32407,ptovrint:False,ptlb:Sombreado,ptin:_Sombreado,varname:node_9827,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.474359,max:1;n:type:ShaderForge.SFN_Multiply,id:2847,x:32415,y:32396,varname:node_2847,prsc:2|A-1193-RGB,B-6301-OUT;n:type:ShaderForge.SFN_Vector3,id:7959,x:32057,y:32646,varname:node_7959,prsc:2,v1:0.4,v2:0.4,v3:0.4;n:type:ShaderForge.SFN_Add,id:6301,x:32262,y:32490,varname:node_6301,prsc:2|A-4902-OUT,B-7959-OUT;proporder:3042-5081-1193-9598;pass:END;sub:END;*/

Shader "Unlit/Raices" {
    Properties {
        _fuerza ("fuerza", Float ) = 1
        _Frecuencia ("Frecuencia", Float ) = 0
        _Fondo ("Fondo", 2D) = "white" {}
        _Sombreado ("Sombreado", Range(0, 1)) = 0.474359
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _Fondo; uniform float4 _Fondo_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _fuerza)
                UNITY_DEFINE_INSTANCED_PROP( float, _Frecuencia)
                UNITY_DEFINE_INSTANCED_PROP( float, _Sombreado)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float _fuerza_var = UNITY_ACCESS_INSTANCED_PROP( Props, _fuerza );
                float _Frecuencia_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Frecuencia );
                v.vertex.xyz += float3(((_fuerza_var*sin((_Frecuencia_var*mul(unity_ObjectToWorld, v.vertex).g)))*o.uv0),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 _Fondo_var = tex2D(_Fondo,TRANSFORM_TEX(i.uv0, _Fondo));
                float _Sombreado_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Sombreado );
                float3 emissive = (_Fondo_var.rgb*(step(_Sombreado_var,dot(lightDirection,i.normalDir))+float3(0.4,0.4,0.4)));
                float3 finalColor = emissive;
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _Fondo; uniform float4 _Fondo_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _fuerza)
                UNITY_DEFINE_INSTANCED_PROP( float, _Frecuencia)
                UNITY_DEFINE_INSTANCED_PROP( float, _Sombreado)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float _fuerza_var = UNITY_ACCESS_INSTANCED_PROP( Props, _fuerza );
                float _Frecuencia_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Frecuencia );
                v.vertex.xyz += float3(((_fuerza_var*sin((_Frecuencia_var*mul(unity_ObjectToWorld, v.vertex).g)))*o.uv0),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
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
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _fuerza)
                UNITY_DEFINE_INSTANCED_PROP( float, _Frecuencia)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                float _fuerza_var = UNITY_ACCESS_INSTANCED_PROP( Props, _fuerza );
                float _Frecuencia_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Frecuencia );
                v.vertex.xyz += float3(((_fuerza_var*sin((_Frecuencia_var*mul(unity_ObjectToWorld, v.vertex).g)))*o.uv0),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
