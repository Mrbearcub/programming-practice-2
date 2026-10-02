using Godot;
using Godot.Collections;
using System;

public partial class player : CharacterBody2D
{
    [Export]
    private float Gravity = 900f;
    [Export]
    private float JumpVelocity { get; set; } = -800f;
    private float ReloadTime { get; set; } = 1f;

    private Vector2 _velocity;
    public override void _PhysicsProcess(double delta) //Вводим гравитацию и высоту прыжка
    {
        _velocity = Velocity;
        if (!IsOnFloor())
        {
            _velocity.Y += Gravity * (float)delta;
        }
        if (IsOnFloor() && Input.IsActionJustPressed("jump"))
        {
            _velocity = Jump(_velocity);
        }
        Velocity = _velocity;
        MoveAndSlide();
    }

    private Vector2 Jump(Vector2 Velocity) //Функция прыжка
    {
        return new Vector2(0, JumpVelocity);
    }

    [Export]
    private float BulletSpeed = 600f;
    [Export]
    private float BulletDamage = 10f;

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("shoot"))
        {
            Shoot();
        }
    }
    private PackedScene BulletScene = GD.Load<PackedScene>("res://bullet.tscn");
    private void Shoot() //Функция стрельбы, создаем пулю на растоянии 50 от игрока по X, задаем ей скорость
    {
        GD.Print("Shooting");
        bullet bullet = (bullet)BulletScene.Instantiate();
        AddSibling(bullet);
        bullet.Position = Position + new Vector2(50, 0);
        bullet.Velocity = new Vector2(BulletSpeed, 0);
        bullet.SetDamage(BulletDamage);

    }

    private void _On_Collision(Area2D area) //Смерть игрока, если в него вошел объект-дамагер
    {
        if (area is DamagingObject)
        {
            GD.Print("Player hit");
            GetTree().Quit();
        }
    }

}
