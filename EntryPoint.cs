using Engine;

public class Game : Application
{
    public Game(Point ScreenSize, Point FontSize, string? Font = null) : base(ScreenSize, FontSize, Font) {
    }

    public override void Process() {
        Screen.SetText(0,0,"lol");
    }
}