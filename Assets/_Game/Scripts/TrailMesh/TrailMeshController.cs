public class TrailMeshController
{
    readonly TrailMeshModel model;
    readonly TrailMeshView view;

    public TrailMeshController (TrailMeshModel model, TrailMeshView view)
    {
        this.model = model;
        this.view = view;
    }

    public void Initialize ()
    {
        view.UpdateMesh(model.Mesh);
    }
}