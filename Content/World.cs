using Engine;

namespace Content;

public class World {
    public Point Size;
    public List<Tile> Data = new();
    public Camera Cam; 

    private Random rnd = new();

    public World() {
        Size = new Point(100, 100);

        for(int x = 0; x < Size.X; x++) {
            for(int y = 0; y < Size.Y; y++) {
                var tile = MakeTile(new Point(x, y));
                if (tile != null)
                    Data.Add(tile);
            }
        }

        Cam = new Camera();
        Cam.Position = new Point(Size.X/2, Size.Y/2);
    }

    private Tile? MakeTile(Point pos) {
        // gen tile
        var canRandom = rnd.Next(200);
        // make tile
        if (canRandom <= 0) {
                // gen texture
                var blockSprite = Resource.CornerTileLeft;
                Texture tex;
                var sTex = "";
                for(int y = 0; y < blockSprite.Length; y++) {
                    for(int x = 0; x < blockSprite[0].Length; x++) {
                        sTex = sTex + blockSprite[y][x]; 
                    }
                }
                tex = new Texture(blockSprite.Length, blockSprite[0].Length, sTex);

                tex.SetColor(ConsoleColor.Red);
                return new Tile(TileId.Stone, TileType.CornerLeft, tex, pos, Resource.TileSize);
        } else {
            // gen texture
            var blockSprite = Resource.BlockTile;
            Texture tex;
            var sTex = "";
            for(int y = 0; y < blockSprite.Length; y++) {
                for(int x = 0; x < blockSprite[0].Length; x++) {
                    sTex = sTex + blockSprite[y][x]; 
                }
            }
            tex = new Texture(blockSprite.Length, blockSprite[0].Length, sTex);

            if (pos.Y <= (Size.Y - (Size.Y/3))) {
                tex.SetColor(ConsoleColor.Black, ConsoleColor.Black);
                return new Tile(TileId.Air, TileType.Block, tex, pos, Resource.TileSize);
            } else if (pos.Y >= (Size.Y - (Size.Y/3)) && pos.Y < (Size.Y/3)) {
                tex.SetColor(ConsoleColor.Green);
                return new Tile(TileId.Dirt, TileType.Block, tex, pos, Resource.TileSize);
            } else {
                tex.SetColor(ConsoleColor.Gray, ConsoleColor.Gray);
                return new Tile(TileId.Stone, TileType.Block, tex, pos, Resource.TileSize);
            }
        }
        return null;
    }

    public void Draw() {
        var localSize = GetCamDimension();
        var startPos = new Point(
            Math.Clamp(Cam.Position.X - (localSize.X/2), localSize.X, (this.Size.X-1)-(localSize.X)), 
            Math.Clamp(Cam.Position.Y - (localSize.Y/2), localSize.Y, (this.Size.Y-1)-(localSize.Y))
        );

        for (int x = 0; x < localSize.X; x+=1) {
            for (int y = 0; y < localSize.Y; y+=1) {
                var tile = GetTile(new Point(startPos.X+x, startPos.Y+y));
                if (tile == null) 
                    continue;

                Screen.SetTexture(y*Resource.TileSize.Y, x*Resource.TileSize.X, tile.Sprite);
            }
        }

        if (Input.GetKeyDown(ConsoleKey.S))
            Cam.Position.Y += 1;
        else if (Input.GetKeyDown(ConsoleKey.W))
            Cam.Position.Y -= 1;
        
        if (Input.GetKeyDown(ConsoleKey.A))
            Cam.Position.X -= 1;
        else if (Input.GetKeyDown(ConsoleKey.D))
            Cam.Position.X += 1;

        
    }

    public Point GetCamDimension() {
        return new Point(Screen.WindowSize.X/Resource.TileSize.X, Screen.WindowSize.Y/Resource.TileSize.Y);
    }

    public Tile? GetTile(Point pos) {
        //foreach (var item in Data) {
        //    if (item.Position == pos) {
        //        return item;
        //    }
        //}
        //return null;
        Screen.SetText(0,0,pos.X.ToString()+":"+pos.Y.ToString());
        return Data[Utility.GetPosition(Size.X, pos.Y, pos.X)];
    }


}