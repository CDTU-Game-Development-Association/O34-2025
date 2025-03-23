using Godot;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene12;

public partial class Scene12Controller : BaseSceneController
{
    [Export] private AnimationPlayer _animationPlayer;
    [Export] private Node2D _camera;
    [Export] private Color _clearColor;
    [Export] private Node2D[] _followGroup;
    [Export] private Node2D _player;
    [Export] private Node2D _cameraStartPos;
    [Export] private Node2D _greenCircle;

    public override void _Ready()
    {
        base._Ready();
        RenderingServer.SetDefaultClearColor(_clearColor);
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent obj)
    {
        if (!obj.Ready) return;
        _animationPlayer.Play("Main");
    }

    /// <summary>
    /// 相机跟随绿色小圆和玩家
    /// </summary>
    private void FollowGroup()
    {
        foreach (Node2D node in _followGroup)
            _camera.Call("append_follow_targets", node);
    }

    /// <summary>
    /// 相机跟随玩家
    /// </summary>
    private void FollowPlayer()
    {
        _camera.Call("set_follow_target", _player);
    }

    private void FollowCameraStartPos()
    {
        _camera.Call("set_follow_target", _cameraStartPos);
    }

    private void FollowGreenCircle()
    {
        _camera.Call("set_follow_target", _greenCircle);
    }
}
