Shader "custom/HologramEfect"
{

properties{
_Color  ("Main Color", Color) = (1,1,1,1)
_MainTex("Texture"   , 2D   ) ="white"{}
_HologramTex("Hologram Texture",2D)="white"{}

_Frecuency("Frecuencia",Range(1,30))=1
_Speed("Speed",Range(0,5))=1

}

SubShader{

//modo de renderisado
Tags{
"RenderType" = "Opaque"
"Queue"="Transparent"
}

Blend SrcAlpha One

Pass{

 CGPROGRAM
 #pragma  vertex 	vertexShader
 #pragma  fragment	fragmentShader
 #include "UnityCG.cginc"
 
 struct vertexInput{
 float4 vertex:POSITION;
 float2 uv:TEXCOORD0;
 };
 
 struct vertexOutput{
 float4 vertex:SV_POSITION;
 float2 uv:TEXCOORD0;
 float2 huv:TEXCOORD1;
 };
 
 float4 	_Color;
 sampler2D	_MainTex;
 float4 	_MainTex_ST;
 sampler2D  _HologramTex;
 float		_Frecuency;
 float		_Speed;
 
 vertexOutput vertexShader(vertexInput i){
 vertexOutput o;
 o.vertex	 = UnityObjectToClipPos(i.vertex);
 //o.position  = UnityObjectToClipPos(i.vertex);
 o.uv		 = TRANSFORM_TEX(i.uv,_MainTex);
 o.huv		 = o.uv;
 o.huv.y	+= _Time * _Speed;
 
 return o;
 }
 
 fixed4 fragmentShader(vertexOutput o): SV_TARGET{
 fixed4 col  = tex2D(_MainTex,o.uv)*_Color;
 fixed4 holo = tex2D(_HologramTex,o.uv);
 
 holo.a		 = abs(sin(o.huv.y * _Frecuency));
 
 return col*holo;
 }
 ENDCG
 
}

}

}
