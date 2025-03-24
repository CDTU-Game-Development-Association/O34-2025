using Godot;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene14;

public partial class Scene14Controller : BaseSceneController
{
    [Export] private AnimationPlayer _ani;
    [Export] private AnimationPlayer _ani2;
    [Export] private Color _clearColor;
    [Export] private Node2D _camera;
    [Export] private Node2D _player;
    [Export] private Node2D _keyPlot;
    [Export] private Node2D _greenCircle;
    [Export] private Node2D _cameraPos;

    public override void _Ready()
    {
        base._Ready();
        RenderingServer.SetDefaultClearColor(_clearColor);
        AudioManager.Instance.PlayAudio(AudioPlayerType.Bgm,
            "res://Assets/Audios/Bgm/SadHuge.mp3");
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        _ani.Play("Main");
    }

    private void Rotate()
    {
        _ani2.Play("Rotate");
    }

    private void QuitGame()
    {
        GetTree().Quit();
    }

    private void FollowPlayer()
    {
        Follow(_player);
    }

    private void FollowKeyPlot()
    {
        Follow(_keyPlot);
    }

    private void FollowGreenCircle()
    {
        Follow(_greenCircle);
    }

    private void FollowCameraPos()
    {
        Follow(_cameraPos);
    }

    private void Follow(Node2D node)
    {
        _camera.Call("set_follow_target", node);
    }
}
