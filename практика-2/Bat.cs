using Godot;
using System;

[GlobalClass]
public partial class Bat : Enemy //Класс летучей мыши - тип врага
{
    [Export]
    private float SpawnX = 1300f;

    [Export]
    private float MinSpawnY = 50f;

    [Export]
    private float MaxSpawnY = 250f;

    [Export]
    private float VerticalSpeed = 100f;

    private float time;

    public override Vector2 GetSpawnPosition() //Меняем спавн, чтобы был на рандомной высоте
    {
        RandomNumberGenerator random = new RandomNumberGenerator();

        float randomY = random.RandfRange(MinSpawnY, MaxSpawnY);

        return new Vector2(SpawnX, randomY);
    }


    protected override void Move(float delta) //Меняем движение, чтобы было по синусоиде
    {
        time += (float)GetProcessDeltaTime();

        Vector2 movement = new Vector2(
            -100f,
            Mathf.Sin(time * 3) * VerticalSpeed
        );

        Position += movement * (float)GetProcessDeltaTime();
    }
}
