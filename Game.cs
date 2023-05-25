using Engine;

public class Game : Application
{
    public Game(Point ScreenSize, Point FontSize, string? Font = null) : base(ScreenSize, FontSize, Font) {
    }

    public override void Process() {
        Screen.SetText(0,0,"Burh duh duh");

        for (int x = 20; x < 30; x++) {
            for (int y = 20; y < 30; y++) {
                Screen.SetText(y,x,"#");
            }
        }

        Screen.SetText(2, 2, "  /\\_/\\  (", ConsoleColor.White, ConsoleColor.DarkRed);
        Screen.SetText(3, 2, " ( o.o ) _)");
        Screen.SetText(4, 2, "  > ^ < (");
        Screen.SetText(5, 2, " ( | | )(");
        Screen.SetText(6, 2, "(__d b__)");
    }
}