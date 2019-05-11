using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Land : MonoBehaviour
{
	[SerializeField]
	private int numOfVertices = 51;
	
	[SerializeField]
	private Range randomRangeTop = new Range(7.0f, 8.3f);

	[SerializeField]
	private Range randomRangeBottom = new Range(1.0f, 2.0f);

	[SerializeField]
	private bool changed = true;

	System.Random random = new System.Random();

	Mesh mesh;

	List<Vector3> verticesList = new List<Vector3>();
	List<int> trianglesList = new List<int>();

	private void Start()
	{
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
	}

	private void Update() {
		if (changed)
		{
			CreateShape();
			UpdateShape();
			changed = false;
		}
	}

	private void CreateShape()
	{
		GenerateVertices();
		GenerateTriangles();
	}

	private void GenerateVertices()
	{
		verticesList.Add(new Vector3(0, 0, 0));

		for (int id = 0; id < numOfVertices; id++)
		{
			if (id % 2 == 0)
			{
				verticesList.Add(new Vector3(verticesList[verticesList.Count - 1].x, GetRandomFloat(randomRangeTop), 0));
			}
			else
			{
				verticesList.Add(new Vector3(verticesList[verticesList.Count - 1].x + GetRandomFloat(randomRangeBottom), 0, 0));
			}
		}
	}

	private void GenerateTriangles()
	{
		for (int id = 2; id < verticesList.Count; id++)
		{
			if (id % 2 == 0)
			{
				trianglesList.Add(id - 2);
				trianglesList.Add(id - 1);
				trianglesList.Add(id);
			}
			else
			{
				trianglesList.Add(id - 1);
				trianglesList.Add(id - 2);
				trianglesList.Add(id);
			}
		}
	}

	private float GetRandomFloat(Range range)
	{
		return (float) (random.NextDouble() * (range.max - range.min) + range.min);
	}

	private void UpdateShape()
	{
		mesh.Clear();

		mesh.vertices = verticesList.ToArray();
		mesh.triangles = trianglesList.ToArray();
		
		verticesList.Clear();
		trianglesList.Clear();
		mesh.RecalculateNormals();
	}
}

[Serializable]
public struct Range
{
	public float min;
	public float max;

	public Range(float min, float max)
	{
		this.min = min;
		this.max = max;
	}
}