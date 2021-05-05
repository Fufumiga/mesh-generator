using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public int scale = 20;

    public float offsetX;
    public float offsetY;

    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        offsetX = Random.Range(0, 999f);
        offsetY = Random.Range(0, 999f);
    }

    void Update()
    {
        renderer.material.mainTexture = GenerateTexture(); 
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        //Creating perlin noise map
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
