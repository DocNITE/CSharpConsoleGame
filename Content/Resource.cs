using Engine;

namespace Content;

public class Resource {
    // some const
    public const ConsoleKey MOVE_UP = ConsoleKey.W;
    public const ConsoleKey MOVE_LEFT = ConsoleKey.A;
    public const ConsoleKey MOVE_DOWN = ConsoleKey.S;
    public const ConsoleKey MOVE_RIGHT = ConsoleKey.D;

    public static Point WORLD_SIZE = new Point(100, 100);
    // some prefaps
    public static string[] HousePrefab = {
        "...xxxxxxxx..",
        "..xxxxxxxxxx.",
        " xxxxxxxxxxxx",
        "...x......x..",
        "...x......x..",
        "...x......x..",
        "...x......x.."
    };
    // some info
    public static Point TileSize = new Point(6,3);
    // some sprites
    public static string[] BlockTile = {
        " ____ ",
        "|    |",
        "|____|"
    };
    public static string[] CornerTileLeft = {
        "   __ ",
        " _/  |",
        "/____|"
    };
    public static string[] CornerTileRight = {
        " __  ",
        "| \\_",
        "|____\\"
    };
    public static string[] CameraTexture = {
        "    ____",
        "|\\_|    |",
        "| . O_O |",
        "|/ |____|"
    };
}

/*
  O  _
 /|\_/|
/ | / 
 / \
 | |

     ____
 |\_|    |
 | . O_O |
 |/ |____|
*/