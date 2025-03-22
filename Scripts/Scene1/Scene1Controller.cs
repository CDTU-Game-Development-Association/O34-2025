using Godot;
using LumiVerseFramework.Common;
using LumiVerseFramework.Managers;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene1;

public partial class Scene1Controller : Node2D
{
    [Export] private AnimationPlayer _animationPlayer;
    [Export] private Node2D[] _cores;

    public override void _Ready()
    {
        base._Ready();
        EventCenterManager.Instance.AddListener<GameStartEvent>(HandleStart);
    }

    private void HandleStart(GameStartEvent e)
    {
        if (!e.Ready) return;
        YumihoshiDebug.Print<Scene1Controller>("测试", "场景1开始");
        _animationPlayer.Play("Main");
    }

    /// <summary>
    /// 播放核心蓄力音效
    /// </summary>
    private void PlayPowerSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/Power.mp3");
    }

    /// <summary>
    /// 播放核心归位音效
    /// </summary>
    private void PlayPowerDoneSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/PowerDone.mp3");
    }

    /// <summary>
    /// 播放机器运转音效
    /// </summary>
    private void PlayMachineRunningSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Environment,
            "res://Assets/Audios/Environment/MachineWorking.mp3");
    }

    /// <summary>
    /// 播放门开音效
    /// </summary>
    private void PlayDoorOpenSfx()
    {
        AudioManager.Instance.PlayAudio(AudioPlayerType.Sfx,
            "res://Assets/Audios/Sfx/DoorOpen.mp3");
    }

    private void ShowColor()
    {
        foreach (Node2D core in _cores) core.Modulate = Colors.White;
    }

    /// <summary>
    /// 加载下一个场景
    /// </summary>
    private void LoadNext()
    {
        SceneManager.Instance.LoadScene("res://Scenes/Root/Scene2.tscn");
    }
}
