using Godot;
using LumiVerseFramework.Common;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene7;

public partial class Scene7Controller : BaseSceneController
{
    [Export] private AnimationPlayer _animationPlayer;
    [Export] private Color _clearColor;

    public override void _Ready()
    {
        base._Ready();
        RenderingServer.SetDefaultClearColor(_clearColor);
        AudioManager.Instance.PlayAudio(AudioPlayerType.Bgm,
            "res://Assets/Audios/Bgm/Sad1.mp3");
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        YumihoshiDebug.Print<Scene7Controller>("测试", "场景7开始");
        _animationPlayer.Play("Main");
    }
}
