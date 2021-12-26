using ProceduralToolkit;
using UnityEngine;
using VContainer;

public class MeshModifier : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float speed;

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;
    MeshDraft draft;
    GameInput input;

    int idx;
    Vector3 offset;
    InputDirection previousDirection = InputDirection.Up;

    void Awake ()
    {
        input = ApplicationRoot.ApplicationContext
            .GameSessionContext
            .Container
            .Resolve<GameInput>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer.material = material;
        draft = new MeshDraft();
    }

    void Update ()
    {
        AddNextBox(input.CurrentInput.Direction);
        UpdateMesh();
        InputDirection direction = input.CurrentInput.Direction;
        previousDirection = direction == InputDirection.None ? previousDirection : direction;
    }

    void AddNextBox (InputDirection direction)
    {
        if (direction.IsOpposite(previousDirection))
            return;

        switch (direction)
        {
            case InputDirection.None:
                AddNextBox(previousDirection);
                break;
            case InputDirection.Up:
                AddMovement(Vector3.forward);
                AddForwardBox();
                break;
            case InputDirection.Down:
                AddMovement(Vector3.back);
                AddBackBox();
                break;
            case InputDirection.Left:
                AddMovement(Vector3.left);
                AddLeftBox();
                break;
            case InputDirection.Right:
                AddMovement(Vector3.right);
                AddRightBox();
                break;
        }
    }

    void AddMovement (Vector3 movement)
    {
        offset += movement * speed * Time.deltaTime;
    }

    void AddForwardBox ()
    {
        draft.AddPartialBox(
            offset,
            Vector3.right,
            Vector3.forward,
            Vector3.up,
            Directions.Left | Directions.Right | Directions.Up
        );
    }

    void AddBackBox ()
    {
        draft.AddPartialBox(
            offset,
            Vector3.left,
            Vector3.back,
            Vector3.up,
            Directions.Left | Directions.Right | Directions.Up
        );
    }

    void AddLeftBox ()
    {
        draft.AddPartialBox(
            offset,
            Vector3.forward,
            Vector3.left,
            Vector3.up,
            Directions.Left | Directions.Right | Directions.Up
        );
    }

    void AddRightBox ()
    {
        draft.AddPartialBox(
            offset,
            Vector3.back,
            Vector3.right,
            Vector3.up,
            Directions.Left | Directions.Right | Directions.Up
        );
    }

    void UpdateMesh ()
    {
        draft.ToMesh(meshFilter.mesh);
    }
}
