using System;
using Godot;
using LumiVerseFramework.Async;
using LumiVerseFramework.Base;
using LumiVerseFramework.Common;
using O342025.Scripts.Scene0;

namespace O342025.Scripts.Managers;

public partial class AudioManager : Singleton<AudioManager>
{
    private PackedScene _audioPlayerScene;
    private AudioNode _audioNode;
    
    // TODO: 音频渐入渐出
    
    public override void _Ready()
    {
        base._Ready();
        _audioPlayerScene =
            GD.Load<PackedScene>("res://Scenes/Audio/AudioNode.tscn");
        _audioNode = _audioPlayerScene.Instantiate() as AudioNode;
        GetTree().Root.CallDeferred("add_child", _audioNode);
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
                if (_audioNode.BgmPlayer.Playing) _audioNode.BgmPlayer.Stop();
                _audioNode.BgmPlayer.Stream = audioStream;
                _audioNode.BgmPlayer.Play();
                break;
            case AudioPlayerType.Sfx:
                _audioNode.SfxPlayer.Stream = audioStream;
                _audioNode.SfxPlayer.Play();
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
