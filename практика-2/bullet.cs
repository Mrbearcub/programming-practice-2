using Godot;
using System;

public partial class bullet : CharacterBody2D //Класс пули
{
    private float Damage = 10f;

    public override void _PhysicsProcess(double delta)
    {
        MoveAndSlide();
    }

    private void _On_Collision(Area2D area) //Пуля или бьет врага или уничтожается об объекты
    {
        GD.Print("Bullet vollide with" + area.Name);
        if (area is Enemy)
        {
            GD.Print("Bullet hit an enemy!");
            Enemy enemy = (Enemy)area;
            enemy.TakeDamage(Damage);
            QueueFree();
        }
        if (area is Obstacle)
        {
            GD.Print("Bullet was destroyed!");
            QueueFree();
        }
    }

    private void _On_Screen_Leave() //Исчезновение пули за экраном
    {
        //GD.Print("ENd");
        QueueFree();
    }

    public void SetDamage(float damage)
    {
        Damage = damage;
    }
}
