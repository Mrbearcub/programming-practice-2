using Godot;
using System;

[GlobalClass]
public partial class Enemy : DamagingObject //Класс врага
{
    [Export]
    protected float Health;

    

    public void TakeDamage(float damage) //Возможность получения урона
    {
        Health -= damage;
        GD.Print($"{Name} took {damage} damage, has {Health} health");
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die() //Возможность умереть
    {
        GD.Print($"{Name} died");
        QueueFree();
    }
}
