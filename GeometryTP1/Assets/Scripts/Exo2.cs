using UnityEngine;

public class Exo2 : MonoBehaviour
{
    public float height;
    public float radius;
    public float nbMeridiens;

    void Start()
    {
        MeshFilter meshfilter = GetComponent<MeshFilter>();
        meshfilter.mesh = CylindreMesh();

    }

    public Mesh CylindreMesh()
    {
        Mesh mesh = new Mesh();
        var vertices = new System.Collections.Generic.List<Vector3>();
        var triangles = new System.Collections.Generic.List<int>();
        for(int i = 0; i<= nbMeridiens; i++)
        {
            float angle = i * (Mathf.PI*2 /nbMeridiens);
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            vertices.Add( new Vector3(x, 0, z));
            vertices.Add( new Vector3(x, height, z));
        }
        for(int i =0; i< nbMeridiens; i++)
        {
            int baseIndex = i * 2;
            // Triangle 1
            triangles.Add(baseIndex);
            triangles.Add(baseIndex+1);
            triangles.Add(baseIndex + 2);
            // Triangle 2
            triangles.Add(baseIndex + 3);
            triangles.Add(baseIndex + 2);
            triangles.Add(baseIndex + 1);
        }
        vertices.Add( new Vector3(0,0,0)); // centre bas
        vertices.Add( new Vector3(0,height,0)); // centre haut
        int centerBottomIndex = vertices.Count - 2;
        int centerTopIndex = vertices.Count - 1;
        for(int i = 0; i< nbMeridiens; i++)
        {
            int baseIndex = i * 2;
            // Triangle bas
            triangles.Add(baseIndex);
            triangles.Add(baseIndex + 2);
            triangles.Add(centerBottomIndex);
            // Triangle haut
            triangles.Add(baseIndex + 3);
            triangles.Add(baseIndex + 1);
            triangles.Add(centerTopIndex);
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        return mesh;
    }
}
