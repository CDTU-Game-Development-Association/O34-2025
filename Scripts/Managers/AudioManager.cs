using System;
using Godot;
using LumiVerseFramework.Base;
using LumiVerseFramework.Common;

namespace O342025.Scripts.Managers;

public partial class AudioManager : Singleton<AudioManager>
{
    private PackedScene _audioPlayerScene;
    private AudioStreamPlayer _bgmPlayer;
    private AudioStreamPlayer _sfxPlayer;

    public override void _Ready()
    {
        base._Ready();
        _audioPlayerScene =
            GD.Load<PackedScene>("res://Scenes/Audio/AudioNode.tscn");
        Node n = _audioPlayerScene.Instantiate();
        GetTree().Root.AddChild(n);
        _bgmPlayer = n.GetNode<AudioStreamPlayer>("AudioStreamPlayer_Bgm");
        _sfxPlayer = n.GetNode<AudioStreamPlayer>("AudioStreamPlayer_Sfx");
    }

    /// <summary>
    /// 播放音频
    /// </summary>
    /// <param name="type"></param>
    /// <param name="audioStream"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void PlayAudio(AudioPlayerType type, AudioStream audioStream)
    {
        switch (type)
        {
            case AudioPlayerType.Bgm:
                if (_bgmPlayer.Playing) _bgmPlayer.Stop();
                _bgmPlayer.Stream = audioStream;
                _bgmPlayer.Play();
                break;
            case AudioPlayerType.Sfx:
                _sfxPlayer.Stream = audioStream;
                _sfxPlayer.Play();
                break;
            default:
                YumihoshiDebug.Error<AudioManager>("播放音频",
                    $"未知的音频类型:{type.ToString()}");
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    /// <summary>
    /// 播放音频
    /// </summary>
    /// <param name="type"></param>
    /// <param name="audioPath"></param>
    public void PlayAudio(AudioPlayerType type, string audioPath)
    {
        var audioSample = GD.Load<AudioStream>(audioPath);
        if (audioSample == null)
        {
            YumihoshiDebug.Error<AudioManager>("播放音频",
                $"音频资源加载失败，找不到音频:{audioPath}");
            return;
        }
        PlayAudio(type, audioSample);
    }
}

public enum AudioPlayerType
{
    Bgm,
    Sfx,
}
