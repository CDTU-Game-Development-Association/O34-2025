using Godot;

namespace O342025.Scripts.Scene7;

public partial class MovingPlatform : RigidBody2D
{
    [Export] private bool _move;
    private Vector2 _offset;
    [Export] private Node2D _player;
    [Export] private float _speed = 100f;

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!_move) return;
        Position += new Vector2(_speed * (float)delta, 0);
        _player.Position = Position + _offset;
    }

    private void Move()
    {
        _move = true;
        _offset = _player.Position - Position;
    }
}
