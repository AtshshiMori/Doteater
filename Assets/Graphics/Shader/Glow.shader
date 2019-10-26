// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Glow" {
    Properties {
        _Color ("Object's Color", Color)   = (0, 1, 0, 1)
        _GlowColor ("Glow's Color", Color) = (1, 0, 0, 0)
        _Strength ("Glow Strength", Range(5.0, 1.0)) = 2.0
    }
    SubShader {
        Pass {      
            Tags { "LightMode" = "ForwardBase" }

            CGPROGRAM

            #pragma vertex vert 
            #pragma fragment frag

            uniform float4 _Color; 

            float4 vert(float4 vertexPos : POSITION) : SV_POSITION {
                return UnityObjectToClipPos(vertexPos);
            }

            float4 frag(void) : COLOR {
                return _Color; 
            }

            ENDCG 
        }

        Pass {
            Tags {
                "LightMode" = "ForwardBase"
                "Queue" = "Transparent"
                "RenderType" = "Transparent"
            }

            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
			// Upgrade NOTE: excluded shader from DX11; has structs without semantics (struct v2f members normalDirection,viewDirection)
			#pragma exclude_renderers d3d11

            #pragma vertex vert
            #pragma fragment frag

            uniform float4 _GlowColor;
            uniform float  _Strength;

            struct vInput {
                float4 vertex : POSITION;
                float4 normal : NORMAL;
            };

            struct v2f {
                float4 position : SV_POSITION;
                float3 normalDirection : TEXCOORD0;
                float3 viewDirection : TEXCOORD1;
            };

            v2f vert(vInput i) {
                v2f o;

                float4x4 modelMatrix        = unity_ObjectToWorld;
                float4x4 modelMatrixInverse = unity_WorldToObject;

                float3 normalDirection = normalize(mul(i.normal, modelMatrixInverse)).xyz;
                float3 viewDirection   = normalize(_WorldSpaceCameraPos - mul(modelMatrix, i.vertex).xyz);

                float4 pos = i.vertex + (i.normal * 0.3);

                o.position        = UnityObjectToClipPos(pos);
                o.normalDirection = normalDirection;
                o.viewDirection   = viewDirection;

                return o;
            }

            float4 frag(v2f i) : COLOR {
                float3 normalDirection = normalize(i.normalDirection);
                float3 viewDirection   = normalize(i.viewDirection);
                float strength = abs(dot(viewDirection, normalDirection));
                float opacity  = pow(strength, _Strength);
                return float4(_GlowColor.xyz, opacity);
            }

            ENDCG
        }
    }
}