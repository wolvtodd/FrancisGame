using UnityEngine;

namespace Francis_Pluguin
{
	public class PolygonTest : MonoBehaviour
	{
		#region Exposed
		public float radius = 1.0f;
		#endregion

		void Start()
		{
			// Create Vector3 vertices
			Vector3[] vertices3D = new Vector3[]
			{
				new Vector3(0.0f, -1.0f, 0.0f) * radius,
				new Vector3(-Mathf.Sqrt(3.0f) / 2.0f, -0.5f, 0.0f) * radius,
				new Vector3(-Mathf.Sqrt(3.0f) / 2.0f, 0.5f, 0.0f) * radius,
				new Vector3(0.0f, 1.0f, 0.0f) * radius,
				new Vector3(Mathf.Sqrt(3.0f) / 2.0f, 0.5f, 0.0f) * radius,
				new Vector3(Mathf.Sqrt(3.0f) / 2.0f, -0.5f, 0.0f) * radius,
			};

			// Use the triangulator to get indices for creating triangles
			Triangulator tr = new Triangulator(vertices3D);
			int[] indices = tr.Triangulate();

			// Create the mesh
			Mesh msh = new Mesh();
			msh.vertices = vertices3D;
			msh.triangles = indices;
			msh.RecalculateNormals();
			msh.RecalculateBounds();

			// Set up game object with mesh;
			gameObject.AddComponent(typeof(MeshRenderer));
			MeshFilter filter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
			filter.mesh = msh;
		}
	}
}