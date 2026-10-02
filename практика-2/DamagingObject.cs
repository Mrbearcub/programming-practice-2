using Godot;
using System;


[GlobalClass]
public partial class DamagingObject : Area2D //Объект, наносящий урон
{
	[Export]
	protected Vector2 velocity = new Vector2(-300f, 0);

    public override void _PhysicsProcess(double delta)
    {
        Move((float)delta);
    }

    protected virtual void Move(float delta) //Функция движения, подгоняем под частоту кадров
    {
        Position += velocity * delta;
    }

    public virtual Vector2 GetSpawnPosition() //Вводим функцию спавна для будущего переопределения
    {
        return GlobalPosition;
    }

    public override void _Ready() 
    {
        VisibleOnScreenNotifier2D notifier = new VisibleOnScreenNotifier2D();
        AddChild(notifier);

    }

    private async void _On_Sreen_Exited() //Т.к. враги спавнятся за экраном, уничтожаем их только после определенного времени
    {
        Timer timer = new Timer();
        timer.WaitTime = 1f;
        timer.OneShot = true;
        AddChild(timer);
        timer.Start();
        await ToSignal(timer, "timeout");
        GD.Print($"{Name} has exited the scene.");
        QueueFree();
    }
}
