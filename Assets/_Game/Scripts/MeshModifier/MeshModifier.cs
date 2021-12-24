using ProceduralToolkit;
using UnityEngine;
using VContainer;

public class MeshModifier : MonoBehaviour
{
    [SerializeField] Material material;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    MeshDraft draft;
    GameInput input;
    int idx;

    void Awake ()
    {
        input = ApplicationRoot.ApplicationContext
            .GameSessionContext
            .Container
            .Resolve<GameInput>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer.material = material;
    }

    void Start ()
    {
        draft = MeshDraft.PartialBox(
            Vector3.right,
            Vector3.forward,
            Vector3.up,
            Directions.Left | Directions.Right | Directions.Up | Directions.Back
        );
        UpdateMesh();
    }

    void Update ()
    {
        // draft.AddPartialBox(
        //     Vector3.forward * idx++,
        //     Vector3.right,
        //     Vector3.forward,
        //     Vector3.up,
        //     Directions.Left | Directions.Right | Directions.Up
        // );
        // UpdateMesh();
    }

    void UpdateMesh ()
    {
        draft.ToMesh(meshFilter.mesh);
    }
}
