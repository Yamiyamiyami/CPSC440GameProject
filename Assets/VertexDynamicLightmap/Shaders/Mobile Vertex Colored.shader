Shader "Mobile/Vertex Colored" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _SpecColor ("Spec Color", Color) = (1,1,1,1)
    _Emission ("Emmisive Color", Color) = (0,0,0,0)
    _Shininess ("Shininess", Range (0.01, 1)) = 0.7
    _MainTex ("Base (RGB)", 2D) = "white" {}
}
 
SubShader {
    Pass {
        Material {
            Shininess [_Shininess]
            Specular [_SpecColor]
            Emission [_Emission]    
        }


        ColorMaterial AmbientAndDiffuse
        Lighting On
		SeparateSpecular Off
        Fog { Mode Off }
        SetTexture [_MainTex] {
            //constantColor [_Color]
            combine texture * primary DOUBLE
        } 
    }
}
 
Fallback " VertexLit", 1
}