using Engine;

namespace Content;

public class World {
    public Point Size;
    public List<Tile> TilesData = new();
    public List<Entity> EntitiesData = new();
    public Camera Cam; 

    private Random rnd = new();

    public World(Point Size) {
        this.Size = Size;

        // make ground
        for(int y = 0; y < Size.Y; y++) {
            for(int x = 0; x < Size.X; x++) {
                Tile? tile;
                if (y > (Size.Y/2)) {
                    tile = MakeTile(new Point(x, y), TileId.Stone);
                } else if (y == (Size.Y/2)) {
                    tile = MakeTile(new Point(x, y), TileId.Dirt);
                } else {
                    tile = MakeTile(new Point(x, y));
                }
                if (tile != null) {
                    TilesData.Add(tile);
                }
            }
        }
        // make prefabs
        int amounts = 3;
        int xoffset = Size.X/amounts;
        for(int i = 0; i < amounts; i++) {
            GeneratePrefab(Resource.HousePrefab, new Point(xoffset * (i+1), Size.Y/2-Resource.HousePrefab.Length));
        }

        Cam = new Camera(new Point((Size.X*Resource.TileSize.X)/2, (Size.Y*Resource.TileSize.Y)/2));
    }

    private Tile? MakeTile(Point pos, TileId tileid = TileId.Air) {
        // gen tile
        var canRandom = rnd.Next(200);
        // make tile
        if (canRandom <= 0) {
                // gen texture
                Texture tex = MakeTexture(Resource.CornerTileLeft);

                tex.SetColor(ConsoleColor.Red);
                return new Tile(TileId.Stone, TileType.CornerLeft, tex, pos, Resource.TileSize);
        } else {
            // gen texture
            Texture tex = MakeTexture(Resource.BlockTile);

            switch (tileid)
            {
                case TileId.Air:
                    tex.SetColor(ConsoleColor.Black, ConsoleColor.Black);
                    return new Tile(TileId.Air, TileType.Block, tex, pos, Resource.TileSize);
                
                case TileId.Stone:
                    tex.SetColor(ConsoleColor.Gray, ConsoleColor.Gray);
                    return new Tile(TileId.Stone, TileType.Block, tex, pos, Resource.TileSize);

                case TileId.Dirt:
                    tex.SetColor(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);
                    return new Tile(TileId.Dirt, TileType.Block, tex, pos, Resource.TileSize);

                default:
                break;
            }
        }
        return null;
    }

    public void GeneratePrefab(string[] prefab, Point pos) {
        var pWidth = prefab[0].Length;
        var pHeight = prefab.Length;

        for(int y = 0; y < pHeight; y++) {
            for(int x = 0; x < pWidth; x++) {
                var charp = prefab[y][x];
                if (charp != '.') {
                    var tile = GetTile(new Point(pos.X + x, pos.Y + y));
                    tile.Id = TileId.Stone;
                    tile.Sprite.SetColor(ConsoleColor.DarkRed);
                } 
            }
        }
    }

    public Texture MakeTexture(string[] textSprite) {
        var blockSprite = textSprite;
        Texture tex;
        var sTex = "";

        for(int y = 0; y < blockSprite.Length; y++) {
            for(int x = 0; x < blockSprite[0].Length; x++) {
                sTex = sTex + blockSprite[y][x]; 
            }
        }

        tex = new Texture(blockSprite.Length, blockSprite[0].Length, sTex);

        return tex;
    }

    public void Draw() {
        var localSize = GetCamDimension();
        var physicalSize = new Point(localSize.X*Resource.TileSize.X, localSize.Y*Resource.TileSize.Y);
        float localCamPosX = Cam.Position.X/Resource.TileSize.X;
        float localCamPosY = Cam.Position.Y/Resource.TileSize.Y;
        var startPos = new Point(
            Math.Clamp((int)Math.Floor(localCamPosX) - (localSize.X/2), localSize.X, (this.Size.X-1)-(localSize.X)) - 1, 
            Math.Clamp((int)Math.Floor(localCamPosY) - (localSize.Y/2), localSize.Y, (this.Size.Y-1)-(localSize.Y)) - 1
        );

        for (int y = 0; y < localSize.Y+1; y+=1) {
            for (int x = 0; x < localSize.X+2; x+=1) {
                var pos = new Point(startPos.X+x, startPos.Y+y);
                var tile = GetTile(pos);
                if (tile == null || tile.Id == TileId.Air) {
                    continue;
                }

                var minPhysicalPos = new Point((Cam.Position.X-(Screen.WindowSize.X/2)), (Cam.Position.Y-(Screen.WindowSize.Y/2)));
                Screen.SetText(10,10,minPhysicalPos.X.ToString());
                Screen.SetTexture(((pos.Y)*Resource.TileSize.Y)-minPhysicalPos.Y, ((pos.X)*Resource.TileSize.X)-minPhysicalPos.X, tile.Sprite);
            }
        }

        // Draw camera
        var cumtex = MakeTexture(Resource.CameraTexture);
        Screen.SetTexture(Screen.WindowSize.Y/2-cumtex.Height/2, Screen.WindowSize.X/2-cumtex.Width/2, MakeTexture(Resource.CameraTexture));
    }

    public void Update() {
        MovePlayer();
        MoveCamera();
    }

    public void MoveCamera() {
        if (Cam.Attached == null) {
            if (Input.GetKeyDown(Resource.MOVE_DOWN))
                Cam.Position.Y += 1;
            else if (Input.GetKeyDown(Resource.MOVE_UP))
                Cam.Position.Y -= 1;

            if (Input.GetKeyDown(Resource.MOVE_LEFT))
                Cam.Position.X -= 1;
            else if (Input.GetKeyDown(Resource.MOVE_RIGHT))
                Cam.Position.X += 1;
        }
    }

    public void MovePlayer() {
        // todo:
    }

    public Point GetCamDimension() {
        return new Point(Screen.WindowSize.X/Resource.TileSize.X, Screen.WindowSize.Y/Resource.TileSize.Y);
    }

    public Tile GetTile(Point pos) {
        //foreach (var item in TilesData) {
        //    if (item.Position == pos) {
        //        return item;
        //    }
        //}
        //return null;
        Screen.SetText(0,0,pos.X.ToString()+":"+pos.Y.ToString());
        return TilesData[Utility.GetPosition(Size.X, pos.Y, pos.X)];
    }


}