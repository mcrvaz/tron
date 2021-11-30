using System;
using ProceduralToolkit;
using UnityEngine;

public class TrailMeshModel
{
    public event Action OnMeshUpdated;

    public Mesh Mesh { get; private set; }

    readonly MeshDraft meshDraft;

    public TrailMeshModel (Mesh mesh, MeshDraft meshDraft)
    {
        this.meshDraft = meshDraft;
        Mesh = mesh;
    }

    public void GenerateInitialCube ()
    {
        meshDraft.AddPartialBox(
            Vector3.zero,
            Vector3.right,
            Vector3.forward,
            Vector3.up,
            Directions.Left | Directions.Right | Directions.Up | Directions.Back
        );
        UpdateMesh();
    }

    public void GenerateAdditionalCube (Vector3 offset)
    {
        meshDraft.AddPartialBox(
            offset,
            Vector3.right,
            Vector3.forward,
            Vector3.up,
            Directions.Left | Directions.Right | Directions.Up
        );
        UpdateMesh();
    }

    void UpdateMesh ()
    {
        meshDraft.ToMesh(Mesh);
        OnMeshUpdated?.Invoke();
    }
}