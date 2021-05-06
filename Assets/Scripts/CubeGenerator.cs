using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CubeGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateCube();
        UpdateMesh();
    }

    void CreateCube()
    {
        vertices = new Vector3[]
        {
            new Vector3 (0, 0, 0),
            new Vector3 (1, 0, 0),
            new Vector3 (1, 1, 0),
            new Vector3 (0, 1, 0),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 1),
            new Vector3 (1, 0, 1),
            new Vector3 (0, 0, 1),
        };

        triangles = new int[]
        {
            2,1,0, //face front
            0,3,2,
            4,7,6, //face back
            4,6,5,
            5,6,1, //face right
            5,1,2,
            3,0,7, //face left
            3,7,4,
            5,2,3, //face top
            5,3,4,
            1,6,7, //face bottom
            1,7,0
        };
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.Optimize();
        mesh.RecalculateNormals();
    }
}
