using Godot;
using O342025.Scripts.Base;

namespace O342025.Scripts.Scene7;

public partial class LastPlatform : Area2D
{
    [Export] private AnimationPlayer _animationPlayer;

    private void OnBodyEntered(Node2D body)
    {
        _animationPlayer.Stop();
        (body as CharacterBody2D).Velocity = Vector2.Zero;
        (body as BasicPlayer).AllowMove = false;
        _animationPlayer.Play("Second");
        QueueFree();
    }
}
