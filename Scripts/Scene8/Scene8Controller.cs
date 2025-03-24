using Godot;
using LumiVerseFramework.Common;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene8;

public partial class Scene8Controller : BaseSceneController
{
    [Export] private AnimationPlayer _animationPlayer;
    [Export] private Color _clearColor;

    public override void _Ready()
    {
        base._Ready();
        RenderingServer.SetDefaultClearColor(_clearColor);
        AudioManager.Instance.PlayAudio(AudioPlayerType.Environment,
            "res://Assets/Audios/Environment/Water.mp3");
        AudioManager.Instance.PlayAudio(AudioPlayerType.Bgm,
            "res://Assets/Audios/Bgm/Sad3.mp3");
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        YumihoshiDebug.Print<Scene8Controller>("载入场景", "场景8就绪");
        _animationPlayer.Play("Main");
    }
}
