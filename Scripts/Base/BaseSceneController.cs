using Godot;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Base;

public partial class BaseSceneController : Node2D
{
    private void StopSfx()
    {
        AudioManager.Instance.StopAudio(AudioPlayerType.Sfx);        
    }

    private void StopBgm()
    {
        AudioManager.Instance.StopAudio(AudioPlayerType.Bgm);
    }

    private void StopEnvironment()
    {
        AudioManager.Instance.StopAudio(AudioPlayerType.Environment);
    }
}
