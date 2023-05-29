using Engine;

namespace Content;

public enum TileId : byte {
    Air = 0,
    Dirt = 1,
    Stone = 2,
}

public enum TileType : byte {
    Block = 0,
    CornerLeft = 1,
    CornerRight = 2
}

public class Tile {
    public TileId Id;
    public TileType Type;
    public Point Position;
    public Point Size;
    public Texture Sprite;

    public Tile(TileId Id, TileType Type, Texture Sprite, Point Position, Point Size) {
        this.Id = Id;
        this.Type = Type;
        this.Position = Position;
        this.Size = Size;
        this.Sprite = Sprite;
    }
}