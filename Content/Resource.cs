using Engine;

namespace Content;

public class Resource {
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
}