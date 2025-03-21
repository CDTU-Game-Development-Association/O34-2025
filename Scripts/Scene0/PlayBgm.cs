using Godot;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene0;

public partial class PlayBgm : Node
{
    public override void _Ready()
    {
        base._Ready();
        AudioManager.Instance.PlayAudio(AudioPlayerType.Bgm,
            "res://Assets/Audios/ThirdPart/Happy.ogg");
    }
}
