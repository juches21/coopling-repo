Shader "Custom/transparencia"
{
  subshader{
	  Tags {"Queue"= "Transparent+1"}
	  Pass{
		  Blend Zero one
		  }
	  }
}
