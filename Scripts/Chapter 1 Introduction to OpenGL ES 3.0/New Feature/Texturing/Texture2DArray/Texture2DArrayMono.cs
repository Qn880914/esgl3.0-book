using System.Collections.Generic;
using UnityEngine;

public class Texture2DArrayMono : MonoBehaviour
{
    [SerializeField] private List<Texture2D> tex2DList;

    [SerializeField] private Renderer m_Renderer;

    private Texture2DArray m_Tex2DArray;

    // Start is called before the first frame update
    void Start()
    {
        if(null == tex2DList || 0 == tex2DList.Count)
        {
            enabled = false;
        }

        m_Tex2DArray = GenTexture2DArray();
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetTexture("_Tex2DArray", m_Tex2DArray);
        propertyBlock.SetInt("_ArrayIndex", 0);
        m_Renderer.SetPropertyBlock(propertyBlock);

        //m_Renderer.sharedMaterial.SetTexture("_Tex2DArray", tex2DArray);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            propertyBlock.SetTexture("_Tex2DArray", m_Tex2DArray);
            propertyBlock.SetInt("_ArrayIndex", 0);
            m_Renderer.SetPropertyBlock(propertyBlock);
        }
        else if (Input.GetKey(KeyCode.B))
        {
            MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            propertyBlock.SetTexture("_Tex2DArray", m_Tex2DArray);
            propertyBlock.SetInt("_ArrayIndex", 1);
            m_Renderer.SetPropertyBlock(propertyBlock);
        }
        else if(Input.GetKey(KeyCode.C))
        {
            MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            propertyBlock.SetTexture("_Tex2DArray", m_Tex2DArray);
            propertyBlock.SetInt("_ArrayIndex", 2);
            m_Renderer.SetPropertyBlock(propertyBlock);
        }
    }

    private Texture2DArray GenTexture2DArray()
    {
        Texture2DArray tex2DArray = 
            new Texture2DArray(tex2DList[0].width, tex2DList[0].height, tex2DList.Count, TextureFormat.RGBA32, false, false);

        for(int i = 0; i < tex2DList.Count; ++ i)
        {
            Graphics.CopyTexture(tex2DList[i], 0, 0, tex2DArray, i, 0);
        }

        return tex2DArray;
    }
}
