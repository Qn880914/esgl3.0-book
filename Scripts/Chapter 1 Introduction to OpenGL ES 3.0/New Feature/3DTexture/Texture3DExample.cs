using UnityEngine;

public class Texture3DExample : MonoBehaviour
{
    private Texture3D m_Texture3D;

    [SerializeField] private Renderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        int size = 16;
        m_Texture3D = new Texture3D(size, size, size, TextureFormat.ARGB32, true);
        var cols = new Color[size * size * size];
        float mul = 1.0f / (size - 1);
        int idx = 0;
        Color c = Color.white;
        for (int z = 0; z < size; ++z)
        {
            for (int y = 0; y < size; ++y)
            {
                for (int x = 0; x < size; ++x, ++idx)
                {
                    c.r = (x != 0) ? x * mul : 1 - x * mul;
                    c.g = (y != 0) ? y * mul : 1 - y * mul;
                    c.b = (z != 0) ? z * mul : 1 - z * mul;
                    cols[idx] = c;
                }
            }
        }
        m_Texture3D.SetPixels(cols);
        m_Texture3D.Apply();

        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetTexture("_Tex3D", m_Texture3D);
        m_Renderer.SetPropertyBlock(propertyBlock);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
