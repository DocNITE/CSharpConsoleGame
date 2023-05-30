using Engine;

namespace Content;

public class Entity {
    public Point Size;
    public Point Position;
    public Vector Velocity;
    public bool Anchored;

    public Entity(Point Position, Point Size, Vector Velocity) {
        this.Position = Position;
        this.Velocity = Velocity;
        this.Anchored = true; // some time
    }
}