Shader "HFT/Scanlines"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_MaskTex("Mask texture", 2D) = "white" {}
		_maskBlend("Mask Blending", Float) = 0.5
		_maskSize("Mask Size", Float) = 1
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag			
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _MaskTex;

			fixed _maskBlend;
			fixed _maskSize;

			fixed4 frag(v2f_img i) : COLOR
			{
				// sample the mask texture
				fixed4 mask = tex2D(_MaskTex, i.uv * _maskSize);

				// sample the main texture
				fixed4 col = tex2D(_MainTex, i.uv);

				return lerp(col, mask, _maskBlend);
			}
			ENDCG
		}
	}
}
