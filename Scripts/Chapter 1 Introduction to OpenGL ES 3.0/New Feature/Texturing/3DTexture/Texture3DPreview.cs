using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture3DPreview : MonoBehaviour
{
    [SerializeField] private Renderer m_Renderer;

    [SerializeField] private Texture3D m_Texture3DPreview;

    [SerializeField] private int m_SampleQuality;

    [SerializeField] private float m_Density;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetInt("_SamplingQuality", m_SampleQuality);
        propertyBlock.SetTexture("_MainTex", m_Texture3DPreview);
        propertyBlock.SetFloat("_Density", m_Density);
        m_Renderer.SetPropertyBlock(propertyBlock);

    }
}
