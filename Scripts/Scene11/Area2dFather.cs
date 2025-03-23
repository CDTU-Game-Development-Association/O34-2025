using Godot;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene10;

public partial class Area2dFather : Area2D
{
    [Export] private AnimationPlayer _circleAnimationPlayer;
    [Export] private AnimationPlayer _mainAnimationPlayer;
    [Export] private Node2D _stone;

    private void OnBodyEntered(Node2D body)
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/OpenSecret.mp3");
        GameManager.Instance.SecretCount++;
        if (GameManager.Instance.SecretCount == 2)
        {
            _stone.QueueFree();
            _circleAnimationPlayer.Stop();
            (body as CharacterBody2D).Velocity = Vector2.Zero;
            _mainAnimationPlayer.Play("Second");
        }

        QueueFree();
    }
}
