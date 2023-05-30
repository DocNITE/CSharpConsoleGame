using Engine;

namespace Content;

public class Camera {
    public Point Position;
    public Entity? Attached;

    public Camera(Point pos, Entity? ent = null) {
        this.Position = pos;
        this.Attached = ent;
    }
}