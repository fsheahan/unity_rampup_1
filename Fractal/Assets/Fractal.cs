using UnityEngine;
using System.Collections;

public class Fractal : MonoBehaviour {
	
	public Mesh mesh;
	public Material material;

	public int maxDepth;

	private int depth;

	private void Start () {
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		gameObject.AddComponent<MeshRenderer>().material = material;
		if (depth < maxDepth) {
			new GameObject("Fractal Child").
				AddComponent<Fractal>().Initialize(this);
		}
	}

	public float childScale;

	private void Initialize (Fractal parent) {
		mesh = parent.mesh;
		material = parent.material;
		maxDepth = parent.maxDepth;
		depth = parent.depth + 1;
		childScale = parent.childScale;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = Vector3.up * (0.5f + 0.5f * childScale);
	}
}