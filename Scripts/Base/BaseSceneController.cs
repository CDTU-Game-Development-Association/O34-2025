using Godot;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Base;

public partial class BaseSceneController : Node2D
{ 
    private void PlayAudio(AudioPlayerType type, AudioStream audioStream)
    {
        AudioManager.Instance.PlayAudio(type, audioStream);
    }

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

    private void LoadNext(string scenePath)
    {
        SceneManager.Instance.LoadScene(scenePath);
    }
}
