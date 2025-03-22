using Godot;

namespace O342025.Scripts.Base;

public partial class BasicPlayer : CharacterBody2D
{
    [ExportGroup("玩家属性配置")] [Export] public bool AllowMove;
    [Export] private float speed = 50000.0f;
    [Export] private float jumpSpeed = -600.0f;
    [Export] private float gravity = 980f;
    private float _doubleGravity;
    private bool _jumpPressed;

    private float _input;

    public override void _Ready()
    {
        base._Ready();
        _doubleGravity = gravity * 2;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        _input = Input.GetAxis("MoveLeft", "MoveRight");
        _jumpPressed = Input.IsActionJustPressed("Jump") || Input.IsActionPressed("Jump");
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        // 应用重力
        Vector2 v = Velocity;
        if (!IsOnFloor())
        {
            if (v.Y <= 0) v.Y += gravity * (float)delta;
            else v.Y += _doubleGravity * (float)delta;
        }
        else
        {
            if (_jumpPressed && AllowMove) v.Y = jumpSpeed;
            else v.Y = 0;
        }

        if (!AllowMove)
        {
            Velocity = v;
            MoveAndSlide();
            return;
        }
        // 移动
        v.X = _input * speed * (float)delta;
        Velocity = v;
        MoveAndSlide();
    }

    /// <summary>
    /// 设置是否允许移动
    /// </summary>
    /// <param name="status"></param>
    public void SetAllowMove(bool status)
    {
        AllowMove = status;
    }
}
