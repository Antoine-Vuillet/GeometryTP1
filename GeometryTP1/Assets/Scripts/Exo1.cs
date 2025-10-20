using UnityEngine;

namespace Exo1Namespace
{
    public class Exo1 : MonoBehaviour
    {
        public int height = 1;
        public int width = 1;


        void Start()
        {
            MeshFilter meshfilter = GetComponent<MeshFilter>();

            meshfilter.mesh = createMesh();


        }

        void Update()
        {

        }

        public Mesh createMesh()
        {
            Mesh mesh = new Mesh();
            var vertices = new System.Collections.Generic.List<Vector3>();
            var triangles = new System.Collections.Generic.List<int>();
            for (int i = 0; i <= height; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    vertices.Add(new Vector3(j, i, 0));
                }
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int topLeft = i * (width + 1) + j;
                    int topRight = topLeft + 1;
                    int bottomLeft = topLeft + (width + 1);
                    int bottomRight = bottomLeft + 1;
                    triangles.Add(topLeft);
                    triangles.Add(bottomLeft);
                    triangles.Add(topRight);
                    triangles.Add(topRight);
                    triangles.Add(bottomLeft);
                    triangles.Add(bottomRight);
                    triangles.Add(bottomRight);
                    triangles.Add(bottomLeft);
                    triangles.Add(topRight);
                    triangles.Add(topRight);
                    triangles.Add(bottomLeft);
                    triangles.Add(topLeft);
                }
            }
            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            return mesh;
        }
    }
}
