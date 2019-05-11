using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Land : MonoBehaviour
{
    Mesh mesh;

	List<Vector3> verticesList = new List<Vector3>();
	List<int> trianglesList = new List<int>();

	private void Start() {
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		CreateShape();
		UpdateShape();
	}

	private void CreateShape()
	{
		System.Random random = new System.Random();
		random.Next();

		verticesList.Add(new Vector3(0, 0, 0));
		verticesList.Add(new Vector3(0, 1, 0));
		verticesList.Add(new Vector3(1, 1, 0));

		trianglesList.Add(0);
		trianglesList.Add(1);
		trianglesList.Add(2);

		// for (int i = 0; i < 20; i++)
		// {
		// 	verticesList.Add(new Vector3(random.Next(), random.Next(), 0));
		// }

		// for (int i = 0; i < 20; i++)
		// {
		// 	trianglesList.Add(random.Next(0, verticesList.Count));
		// 	trianglesList.Add(random.Next(0, verticesList.Count));
		// 	trianglesList.Add(random.Next(0, verticesList.Count));
		// }
		
	}

	private void UpdateShape()
	{
		mesh.Clear();

		mesh.vertices = verticesList.ToArray();
		mesh.triangles = trianglesList.ToArray();

		mesh.RecalculateNormals();
	}
}
