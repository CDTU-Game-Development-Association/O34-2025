using Godot;
using LumiVerseFramework.Common;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene6;

public partial class Scene6Controller : BaseSceneController
{
    [Export] private AnimationPlayer _animationPlayer;
    [Export] private Color _clearColor;
    [Export] private Node2D _player;
    
    public override void _Ready()
    {
        base._Ready();
        RenderingServer.SetDefaultClearColor(_clearColor);
        AudioManager.Instance.PlayAudio(AudioPlayerType.Bgm,
            "res://Assets/Audios/Bgm/Fight.mp3");
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }
    
    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        YumihoshiDebug.Print<Scene6Controller>("测试", "场景6开始");
        _animationPlayer.Play("Main");
    }

    private void Last()
    {
        _player.Position = new Vector2(14288.0f, -96.0f);
    }
}
