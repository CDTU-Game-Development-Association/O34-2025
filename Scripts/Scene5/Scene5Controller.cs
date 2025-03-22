using Godot;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene5;

public partial class Scene5Controller : BaseSceneController
{
    [Export] private AnimationPlayer _animationPlayer;
    [Export] private Node2D _black;
    [Export] private Node2D _camera;
    private bool _enableFollowMother;
    [Export] private Node2D _mother;
    [Export] private Node2D _player;

    public override void _Ready()
    {
        base._Ready();
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!_enableFollowMother) return;
        _player.Position = _mother.Position + new Vector2(0, -123);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        _animationPlayer.Play("Main");
    }

    private void SetFollowBlack()
    {
        _camera.Call("set_follow_target", _black);
    }

    private void SetFollowPlayer()
    {
        _camera.Call("set_follow_target", _player);
    }

    private void SetPlayerPosOnMother()
    {
        _enableFollowMother = true;
    }
}
