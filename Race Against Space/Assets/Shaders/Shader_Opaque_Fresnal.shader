// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:5396,x:32821,y:32699,varname:node_5396,prsc:2|emission-8830-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:207,x:32098,y:32690,ptovrint:False,ptlb:MainTexture,ptin:_MainTexture,varname:node_207,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:376,x:32271,y:32651,varname:node_376,prsc:2,ntxv:0,isnm:False|TEX-207-TEX;n:type:ShaderForge.SFN_VertexColor,id:3157,x:32221,y:32846,varname:node_3157,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:2306,x:32107,y:33196,ptovrint:False,ptlb:FresnelPower,ptin:_FresnelPower,varname:node_2306,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_ValueProperty,id:1855,x:31952,y:33080,ptovrint:False,ptlb:FresnelValue,ptin:_FresnelValue,varname:node_1855,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Fresnel,id:8039,x:32107,y:33060,varname:node_8039,prsc:2|EXP-1855-OUT;n:type:ShaderForge.SFN_Power,id:8521,x:32282,y:33027,varname:node_8521,prsc:2|VAL-8039-OUT,EXP-2306-OUT;n:type:ShaderForge.SFN_Add,id:8830,x:32656,y:32821,varname:node_8830,prsc:2|A-8911-RGB,B-6802-OUT;n:type:ShaderForge.SFN_Multiply,id:6802,x:32420,y:32933,varname:node_6802,prsc:2|A-3157-RGB,B-8521-OUT;n:type:ShaderForge.SFN_Color,id:8911,x:32452,y:32671,ptovrint:False,ptlb:node_8911,ptin:_node_8911,varname:node_8911,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;proporder:207-2306-1855-8911;pass:END;sub:END;*/

Shader "Custom/Opaque_Fresnel" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _FresnelPower ("FresnelPower", Float ) = 3
        _FresnelValue ("FresnelValue", Float ) = 2
        _node_8911 ("node_8911", Color) = (0,0,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _FresnelPower;
            uniform float _FresnelValue;
            uniform float4 _node_8911;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 emissive = (_node_8911.rgb+(i.vertexColor.rgb*pow(pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelValue),_FresnelPower)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
