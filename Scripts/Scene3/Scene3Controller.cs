using Godot;
using LumiVerseFramework.Common;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene3;

public partial class Scene3Controller : BaseSceneController
{
    [Export] private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        base._Ready();
        AudioManager.Instance.PlayAudio(AudioPlayerType.Bgm,
            "res://Assets/Audios/Bgm/Sad.mp3");
        AudioManager.Instance.PlayAudio(AudioPlayerType.Environment,
            "res://Assets/Audios/Environment/MachineWorking.mp3");
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        YumihoshiDebug.Print<Scene3Controller>("测试", "场景3开始");
        _animationPlayer.Play("Main");
    }

    private void LoadNext()
    {
        SceneManager.Instance.LoadScene("res://Scenes/Root/Scene4.tscn", true);
    }

    private void PlaySlowWalkSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/SlowWalk.mp3");
    }

    private void PlayBadSmile()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/BadSmile.mp3");
    }

    private void PlayExplosionSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Explosion.mp3");
    }

    private void PlayAttackSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Attack.mp3");
    }
}
