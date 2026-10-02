using Godot;
using System;
using System.Security.Cryptography;
using RandomNumberGenerator = Godot.RandomNumberGenerator;

public partial class Field : Node2D
{
   
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
    }

    private void _OnSpawnTimerTimeout()
    {
        GD.Print("Spawn");
        SpawnEnemy();
    }
    [Export]
    private Godot.Collections.Array<PackedScene> Objects = new Godot.Collections.Array<PackedScene>();
    private RandomNumberGenerator random = new RandomNumberGenerator();

    private void SpawnEnemy() //Спавним рандомных врагов с определенной периодичностью
    {
        int RandomIndex = random.RandiRange(0, Objects.Count - 1);
        GD.Print($"Spawn enemy {Objects[RandomIndex].ResourcePath}");
        DamagingObject obj = (DamagingObject)Objects[RandomIndex].Instantiate();
        AddChild(obj);
        obj.Position = obj.GetSpawnPosition();

    }
}
