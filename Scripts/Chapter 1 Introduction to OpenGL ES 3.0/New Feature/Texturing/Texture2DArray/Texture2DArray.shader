Shader "Unlit/Texture2DArray"
{
	Properties
	{
		_Tex2DArray("_Tex2DArray", 2DArray) = ""{}
		_ArrayIndex("_ArrayIndex", int) = 0
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"
			UNITY_DECLARE_TEX2DARRAY(_Tex2DArray);
			int _ArrayIndex;

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD;
			};

			v2f vert(appdata_base v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				return o;
			}

			float4 frag(v2f i) : COLOR
			{
				return UNITY_SAMPLE_TEX2DARRAY(_Tex2DArray, float3(i.uv, _ArrayIndex));
			}

		ENDCG
	}
	}
}
