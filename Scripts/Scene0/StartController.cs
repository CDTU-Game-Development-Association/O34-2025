using Godot;
using LumiVerseFramework.Managers;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene0;

public partial class StartController : Node
{
    [Export] private AnimationPlayer _cameraAnimationPlayer;
    [Export] private AnimationPlayer _guardAnimationPlayer;

    public override void _Ready()
    {
        base._Ready();
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        AudioManager.Instance.PlayAudio(AudioPlayerType.Bgm,
            "res://Assets/Audios/ThirdPart/Happy.ogg");
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/GuardWalk.mp3");
        _cameraAnimationPlayer.Play("MoveLeft");
        _guardAnimationPlayer.Play("Guard");
        _cameraAnimationPlayer.AnimationFinished += LoadNextScene;
    }

    private void LoadNextScene(StringName name)
    {
        SceneManager.Instance.LoadScene("res://Scenes/Root/Scene1.tscn");
    }
}
