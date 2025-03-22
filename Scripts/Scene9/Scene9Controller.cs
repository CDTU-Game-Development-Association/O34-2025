using Godot;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene9;

public partial class Scene9Controller : BaseSceneController
{
    [Export] private AnimationPlayer _animationPlayer;
    [Export] private Color _clearColor;

    public override void _Ready()
    {
        base._Ready();
        RenderingServer.SetDefaultClearColor(_clearColor);
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        _animationPlayer.Play("Main");
    }
}
