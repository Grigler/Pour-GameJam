Shader "Custom/Metaballs_Lava" {
Properties {    
    _MainTex ("Texture", 2D) = "white" { }    
}
/// <summary>
/// Multiple metaball shader.
/// 
/// Separates each particle by color and overrides it with the one specified.
/// Notice the texture that passes through this shader only looks at particles, and has a black background.
/// The core element for the color merging is the floor function, try tweaking it to achive the desired result.
///
/// Visit: www.codeartist.mx for more stuff. Thanks for checking out this example.
/// Credit: Rodrigo Fernandez Diaz
/// Contact: q_layer@hotmail.com
/// </summary>
SubShader {
	Tags {"Queue" = "Transparent" }
    Pass {
    Blend SrcAlpha OneMinusSrcAlpha     
	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag	
	#include "UnityCG.cginc"	
	float4 _Color;
	sampler2D _MainTex;	
	struct v2f {
	    float4  pos : SV_POSITION;
	    float2  uv : TEXCOORD0;
	};	
	float4 _MainTex_ST;		
	v2f vert (appdata_base v){
	    v2f o;
	    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
	    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
	    return o;
	}	
	
	// Here goes the metaball magic
	float COLOR_TRESHHOLD=0.2; //To separate and process each color.		
	half4 frag (v2f i) : COLOR{		
		half4 texcol= tex2D (_MainTex, i.uv); 
		half4 finalColor= texcol;	
		if (texcol.a < 0.3)
		{
			finalColor = half4(0.0,0.0,0.0,0.0);
		}	
		else if (texcol.a <0.7)
		{		
			finalColor.a = 0.7;
		}
		else
		{
			finalColor.a = 1.0;
		}

	    return finalColor;
	}
	ENDCG

    }
}
Fallback "VertexLit"
} 