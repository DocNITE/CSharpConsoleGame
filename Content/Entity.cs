using Engine;

namespace Content;

public class Entity {
    public Point Position;
    public Vector Velocity;

    public Entity(Point Position, Vector Velocity) {
        this.Position = Position;
        this.Velocity = Velocity;
    }
}