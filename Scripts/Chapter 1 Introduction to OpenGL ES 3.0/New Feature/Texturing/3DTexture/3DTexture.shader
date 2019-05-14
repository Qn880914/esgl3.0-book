Shader "Unlit/3DTexture"
{
	Properties
	{
		_Tex3D("_Tex3D", 3D) = ""{}
	}

		SubShader
	{
		Pass
		{
			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

			sampler3D _Tex3D;
			float4 _Tex3D_ST;

			struct v2f
			{
				float3 uv : TEXCOORD;
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				//o.uv = TRANSFORM_TEX(v.texcoord, _Tex3D);
				o.uv = v.vertex.xyz*0.5 + 0.5;
				return o;
			}

			float4 frag(v2f i) : COLOR
			{
				return tex3D(_Tex3D, i.uv);
			}
			ENDCG
		}
	}
}
