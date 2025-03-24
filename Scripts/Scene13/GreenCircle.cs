using Godot;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene13;

public partial class GreenCircle : RigidBody2D
{
    private bool _isPositiveXDirection;
    private bool _move;

    [ExportGroup("跟随指引玩家配置")] [Export] private Node2D _player;

    [Export] private float _speed = 300f;
    [Export] private float _maxDistance = 322f;
    [Export] private float _jumpForce = 45f;

    public override void _Process(double delta)
    {
        base._Process(delta);
        Follow(delta);
        Jump();
    }

    private void Follow(double delta)
    {
        float xDistance = Mathf.Abs(_player.Position.X - Position.X);
        if (xDistance >= _maxDistance)
        {
            if (_move)
            {
                LinearVelocity = Vector2.Zero;
                Vector2 pos = Position;
                pos.Y = 100f;
                Position = pos;
            }
            _move = false;
            return;
        }
        // 超出距离，跟随玩家
        _isPositiveXDirection = _player.Position.X - Position.X > 0;
        _move = true;
        LinearVelocity = _isPositiveXDirection
            ? new Vector2(-_speed, 0f)
            : new Vector2(_speed, 0f);
    }

    private void Jump()
    {
        if (_move || !IsOnFloor()) return;
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Jump.mp3");
        ApplyCentralImpulse(new Vector2(0, -_jumpForce));
    }

    private bool IsOnFloor()
    {
        return GetCollidingBodies().Count > 0;
    }
}
