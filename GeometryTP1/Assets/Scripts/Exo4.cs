using UnityEngine;

public class Exo4 : MonoBehaviour
{
    public float height;
    public float radius;
    public int nbMeridiens;
    public float TroncH;

    void Start()
    {
        MeshFilter meshfilter = GetComponent<MeshFilter>();
        meshfilter.mesh = ConeMesh();

    }

    public Mesh ConeMesh()
    {
        Mesh mesh = new Mesh();
        var vertices = new System.Collections.Generic.List<Vector3>();
        var triangles = new System.Collections.Generic.List<int>();
        //Centre du cercle bas
        vertices.Add(new Vector3(0, 0, 0));
        int baseCenterIndex = 0;
        //Centre du cercle haut
        float topRadius = radius *(height - TroncH)/ height;
        vertices.Add(new Vector3(0, TroncH, 0));
        int topIndex = 1;
        //Vertice cercle base
        for (int i = 0; i < nbMeridiens; i++)
        {
            float angle = i * (Mathf.PI * 2 / nbMeridiens);
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            vertices.Add(new Vector3(x, 0, z));
        }
        if (TroncH < height)
        {
            //Vertice cercle haut
            for (int i = 0; i < nbMeridiens; i++)
            {
                float angle = i * (Mathf.PI * 2 / nbMeridiens);
                float x = Mathf.Cos(angle) * topRadius;
                float z = Mathf.Sin(angle) * topRadius;
                vertices.Add(new Vector3(x, TroncH, z));
            }
            //Cotés si tronqué (version chelou du cyclindre car je n'ai les vertices côtes à côtes dans la liste)
            for (int i = 0; i < nbMeridiens; i++)
            {
                int next = (i + 1) % nbMeridiens;
                int baseV = i + 2;
                int topV = i + 2 + nbMeridiens;

                // Triangle 1
                triangles.Add(baseV);
                triangles.Add(topV);
                triangles.Add(2 + next);

                // Triangle 2
                triangles.Add(topV);
                triangles.Add(2 + nbMeridiens + next);
                triangles.Add(2 + next);
            }
            //Face haute (j'ai essayé  de commencer à nbMeridiens, mais je n'ai pas réussi à le faire fonctionner)
            for (int i = 0; i < nbMeridiens; i++)
            {
                int next = (i + 1) % nbMeridiens;
                triangles.Add(2 + nbMeridiens + i);
                triangles.Add(topIndex);
                triangles.Add(2 + nbMeridiens + next);
            }
        }
        else
        {
            //Côtés non tronqué
            for (int i = 0; i < nbMeridiens; i++)
            {
                int current = 2 + i;
                int next = 2 + (i + 1) % nbMeridiens;
                triangles.Add(current);
                triangles.Add(topIndex);
                triangles.Add(next);
            }
        }
        //cercle bas
        for (int i = 0; i < nbMeridiens; i++)
        {
            int current = 2 + i;
            int next = 2 + (i + 1) % nbMeridiens;

            triangles.Add(next);
            triangles.Add(baseCenterIndex);
            triangles.Add(current);
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return mesh;
    }
}
