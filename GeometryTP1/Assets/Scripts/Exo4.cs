using UnityEngine;

public class Exo4 : MonoBehaviour
{
    public float height;
    public float radius;
    public float nbMeridiens;
    public float TroncH;

    void Start()
    {
        MeshFilter meshfilter = GetComponent<MeshFilter>();
        meshfilter.mesh = ConeMesh();

    }


    void Update()
    {

    }

    public Mesh ConeMesh()
    {
        Mesh mesh = new Mesh();
        var vertices = new System.Collections.Generic.List<Vector3>();
        var triangles = new System.Collections.Generic.List<int>();
        vertices.Add(new Vector3(0, 0, 0));
        int baseCenterIndex = 0;
        vertices.Add(new Vector3(0, height, 0));
        int topIndex = 1;
        for (int i = 0; i <= nbMeridiens; i++)
        {
            float angle = i * (Mathf.PI * 2 / nbMeridiens);
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            vertices.Add(new Vector3(x, 0, z));
        }
        for (int i = 2; i < nbMeridiens+2; i++)
        {
            // Triangle 1
            triangles.Add(i);
            triangles.Add(topIndex);
            triangles.Add(i+ 1);
        }
        for (int i = 2; i < nbMeridiens+2; i++)
        {
            int baseIndex = i * 2;
            // Triangle bas
            triangles.Add(i + 1);
            triangles.Add(baseCenterIndex);
            triangles.Add(i);
        }
        Debug.Log(vertices.Count);
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        return mesh;
    }
}
