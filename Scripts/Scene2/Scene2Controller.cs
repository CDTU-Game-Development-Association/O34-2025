using Godot;
using LumiVerseFramework.Managers;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene2;

public partial class Scene2Controller : BaseSceneController
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

    private void StopBgm()
    {
        AudioManager.Instance.StopAudio(AudioPlayerType.Bgm);
    }

    private void PlayGrassShakeSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/GrassShake.mp3");
    }

    private void PlayGuardSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/GuardWalk.mp3");
    }

    private void PlayFindSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Find.mp3");
    }

    private void PlayConfusedSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Confused.mp3");
    }

    private void PlayGrassShake2Sfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/GrassShake2.wav");
    }

    private void PlayRunSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Run.mp3");
    }

    private void StopSfx()
    {
        AudioManager.Instance.StopAudio(AudioPlayerType.Sfx);
    }

    private void PlayAttackSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Attack.mp3");
    }

    private void PlayCatSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Cat.mp3");
    }
}
