using UnityEngine;

public class TrailMeshView : MonoBehaviour
{
    [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }
    [field: SerializeField] public MeshFilter MeshFilter { get; private set; }

    public void UpdateMesh (Mesh mesh)
    {
        MeshFilter.mesh = mesh;
    }
}