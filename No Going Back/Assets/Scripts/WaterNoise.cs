using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterNoise : MonoBehaviour
{
    public float power;
    public float scale;
    public float timeScale;

    float xOffset;
    float yOffset;
    MeshFilter mf;

    void Start ()
    {
        mf = GetComponent<MeshFilter>();
        GenerateNoise();
	}
	
	void Update () {
        GenerateNoise();
        xOffset += Time.deltaTime * timeScale;
        yOffset += Time.deltaTime * timeScale;
    }

    void GenerateNoise()
    {
        Vector3[] vertices = mf.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * power;
        }

        mf.mesh.vertices = vertices;
    }

    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + yOffset;
        float yCord = y * scale + yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
