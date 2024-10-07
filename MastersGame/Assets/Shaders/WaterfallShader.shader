Shader "Unlit/WaterfallShader"
{
    Properties
    {
        [Space(20)][Header(Noise Properties)][Space] 
        _NoiseTex ("Noise Texture", 2D) = "white" {} // Noise texture property
        _NoiseScale ("Noise Scale", Float) = 1.0 // Scale for world space noise mapping
        _FBMOctaves ("FBM Octaves", Int) = 5 

        [Space(20)][Header(Water Properties)][Space] 
        _FlowSpeed ("Flow Speed", Float) = 0.5
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
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float3 worldPos : TEXCOORD0;
                float3 normal : TEXCOORD1;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _NoiseTex;
            float _NoiseStrength;
            float _NoiseScale;
            float _FlowSpeed;
            int _FBMOctaves;

            // generates fractal brownian motion noise
            float fbm(float2 uv)
            {
                float value = 0.0;
                float amplitude = 0.5;
                float frequency = 1.0;

                for (int i = 0; i < _FBMOctaves; i++)
                {
                    value += amplitude * tex2D(_NoiseTex, uv * frequency).r;
                    uv *= 2.0; // Doubles frequency for each octave
                    amplitude *= 0.5; // Decreases amplitude for each octave
                }
                return value;
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.normal = normalize(mul((float3x3)unity_ObjectToWorld, v.normal.xyz));

                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Calculate time offset for time by speed
                float timeOffset = _Time.y * _FlowSpeed;

                // Get absolute normal to ignore direction
                float3 absNormal = abs(i.normal); 

                // If the surface is vertical use worldPos.y for UV projection
                float2 worldUV = float2(i.worldPos.x, i.worldPos.z - timeOffset) * _NoiseScale;

                // Generate texture value based on the worldUV
                float textureOut = fbm(worldUV);

                float3 dotResult = dot(i.normal + textureOut, float3(0,1,0));
                float3 shine = step(0.4, dotResult) * step(dotResult, 0.9);

                fixed4 finalCol = float4(shine, 1);

                // Apply fog
                UNITY_APPLY_FOG(i.fogCoord, finalCol);

                return finalCol;
            }
            ENDCG
        }
    }
}
