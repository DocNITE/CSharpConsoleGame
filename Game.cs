﻿using Engine;
using Content;

public class Game : Application
{
    public World? GameWorld;

    public Game(Point ScreenSize, Point FontSize, string? Font = null) : base(ScreenSize, FontSize, Font) {
    }

    public override void Initialize() {
        GameWorld = new World(Resource.WORLD_SIZE);
    }

    public override void Process() {
        GameWorld.Update();
        GameWorld.Draw();
    }
}