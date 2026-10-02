using Godot;
using System;

public partial class Rock : Obstacle
{
    [Export]
    private float SpawnX = 1300f;
    [Export]
    private float SpawnY = 450f;

    public override Vector2 GetSpawnPosition() //Спавним за экраном
    {
        return new Vector2(SpawnX, SpawnY);
    }


}
