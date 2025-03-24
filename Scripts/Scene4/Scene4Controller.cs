using Godot;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene4;

public partial class Scene4Controller : BaseSceneController
{
    [Export] private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        base._Ready();
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        _animationPlayer.Play("Main");
    }

    private void PlayBabyCrySfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/BabyCry.mp3");
    }

    private void PlayHappy2Bgm()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Bgm,
            "res://Assets/Audios/Bgm/Happy2.mp3");
    }
}
