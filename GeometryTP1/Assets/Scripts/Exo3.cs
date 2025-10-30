using NUnit.Framework;
using UnityEngine;

public class Exo3 : MonoBehaviour
{
    public float radius;
    public int nbMeridiens;
    public float nbParalleles;
    void Start()
    {
        MeshFilter meshfilter = GetComponent<MeshFilter>();
        meshfilter.mesh = SphereMesh();

    }

    public Mesh SphereMesh()
    {
        Mesh mesh = new Mesh();
        var vertices = new System.Collections.Generic.List<Vector3>();
        var triangles = new System.Collections.Generic.List<int>();

        //Création des vertices par rapport au centre
        for (int i = 0; i <= nbParalleles; i++)
        {
            float phi = Mathf.PI * i / nbParalleles;
            float y = Mathf.Cos(phi) * radius;
            float r = Mathf.Sin(phi) * radius;
            for (int j = 0; j <= nbMeridiens; j++)
            {
                float theta = 2 * Mathf.PI * j / nbMeridiens;
                float x = Mathf.Cos(theta) * r;
                float z = Mathf.Sin(theta) * r;
                vertices.Add(new Vector3(x, y, z));
            }
        }

        for (int i = 0; i < nbParalleles; i++)
        {
            for (int j = 0; j < nbMeridiens; j++)
            {
                int first = i * (nbMeridiens + 1) + j;
                int second = first + nbMeridiens + 1;
                triangles.Add(first);
                triangles.Add(second);
                triangles.Add(first + 1);
                triangles.Add(second);
                triangles.Add(second + 1);
                triangles.Add(first + 1);
            }
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        return mesh;
    }
}
