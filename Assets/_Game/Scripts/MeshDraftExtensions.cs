using ProceduralToolkit;
using UnityEngine;

public static class MeshDraftExtensions
{
    public static MeshDraft AddPartialBox (
        this MeshDraft draft,
        Vector3 offset,
        Vector3 width,
        Vector3 depth,
        Vector3 height,
        Directions parts,
        bool generateUV = true
    )
    {
        Vector3 v000 = -width / 2 - depth / 2 - height / 2;
        Vector3 v001 = v000 + height;
        Vector3 v010 = v000 + width;
        Vector3 v011 = v000 + width + height;
        Vector3 v100 = v000 + depth;
        Vector3 v101 = v000 + depth + height;
        Vector3 v110 = v000 + width + depth;
        Vector3 v111 = v000 + width + depth + height;
        if (generateUV)
        {
            Vector2 uv0 = new Vector2(0, 0);
            Vector2 uv1 = new Vector2(0, 1);
            Vector2 uv2 = new Vector2(1, 1);
            Vector2 uv3 = new Vector2(1, 0);

            if (parts.HasFlag(Directions.Left)) draft.AddQuad(offset, v100, v101, v001, v000, true, uv0, uv1, uv2, uv3);
            if (parts.HasFlag(Directions.Right)) draft.AddQuad(offset, v010, v011, v111, v110, true, uv0, uv1, uv2, uv3);
            if (parts.HasFlag(Directions.Down)) draft.AddQuad(offset, v010, v110, v100, v000, true, uv0, uv1, uv2, uv3);
            if (parts.HasFlag(Directions.Up)) draft.AddQuad(offset, v111, v011, v001, v101, true, uv0, uv1, uv2, uv3);
            if (parts.HasFlag(Directions.Back)) draft.AddQuad(offset, v000, v001, v011, v010, true, uv0, uv1, uv2, uv3);
            if (parts.HasFlag(Directions.Forward)) draft.AddQuad(offset, v110, v111, v101, v100, true, uv0, uv1, uv2, uv3);
        }
        else
        {
            if (parts.HasFlag(Directions.Left)) draft.AddQuad(offset, v100, v101, v001, v000, true);
            if (parts.HasFlag(Directions.Right)) draft.AddQuad(offset, v010, v011, v111, v110, true);
            if (parts.HasFlag(Directions.Down)) draft.AddQuad(offset, v010, v110, v100, v000, true);
            if (parts.HasFlag(Directions.Up)) draft.AddQuad(offset, v111, v011, v001, v101, true);
            if (parts.HasFlag(Directions.Back)) draft.AddQuad(offset, v000, v001, v011, v010, true);
            if (parts.HasFlag(Directions.Forward)) draft.AddQuad(offset, v110, v111, v101, v100, true);
        }
        return draft;
    }

    public static MeshDraft AddQuad (this MeshDraft draft, Vector3 offset, Vector3 vertex0, Vector3 vertex1, Vector3 vertex2, Vector3 vertex3, bool calculateNormal, Vector2 uv0, Vector2 uv1, Vector2 uv2, Vector2 uv3)
    {
        return draft.AddQuad(vertex0 + offset, vertex1 + offset, vertex2 + offset, vertex3 + offset, calculateNormal, uv0, uv1, uv2, uv3);
    }

    public static MeshDraft AddQuad (this MeshDraft draft, Vector3 offset, Vector3 vertex0, Vector3 vertex1, Vector3 vertex2, Vector3 vertex3, bool calculateNormal)
    {
        return draft.AddQuad(vertex0 + offset, vertex1 + offset, vertex2 + offset, vertex3 + offset, calculateNormal);
    }
}
