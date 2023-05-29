using Engine;
using Content;

public class Game : Application
{
    public World? GameWorld;

    public Game(Point ScreenSize, Point FontSize, string? Font = null) : base(ScreenSize, FontSize, Font) {
    }

    public override void Initialize() {
        GameWorld = new World();
    }

    public override void Process() {
        GameWorld.Draw();
    }
}