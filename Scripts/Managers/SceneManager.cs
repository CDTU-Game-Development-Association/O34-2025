using System.Threading.Tasks;
using Godot;
using LumiVerseFramework.Async;
using LumiVerseFramework.Base;
using LumiVerseFramework.Managers;
using O342025.Scripts.UI;

namespace O342025.Scripts.Managers;

public partial class SceneManager : Singleton<SceneManager>
{
    private FullscreenMask _fullscreenMask;

    private string _scenePath;
    private bool _stopBgm;
    private bool _stopEnvironment;

    public override void _Ready()
    {
        base._Ready();
        UiManager.Instance.FullscreenMaskNode.FadeInCompleted +=
            HandleLoadScene;
    }

    /// <summary>
    /// 切换场景
    /// </summary>
    /// <param name="scenePath"></param>
    /// <param name="stopBgm"></param>
    /// <param name="stopEnvironment"></param>
    public void LoadScene(string scenePath, bool stopBgm = false, bool stopEnvironment = true)
    {
        _scenePath = scenePath;
        _stopBgm = stopBgm;
        _stopEnvironment = stopEnvironment;
        UiManager.Instance.FadeIn();
    }

    private async void HandleLoadScene()
    {
        // 启动异步加载
        ResourceLoader.LoadThreadedRequest(_scenePath);
        while (ResourceLoader.LoadThreadedGetStatus(_scenePath) != ResourceLoader.ThreadLoadStatus.Loaded)
        {
            await WaitTask.WaitForSeconds(this, 0.1f);
        }
        
        // 加载完成，切换场景
        var scene = ResourceLoader.LoadThreadedGet(_scenePath) as PackedScene;
        if (_stopBgm)
            AudioManager.Instance.StopAudio(AudioPlayerType.Bgm);
        if (_stopEnvironment)
            AudioManager.Instance.StopAudio(AudioPlayerType.Environment);
        AudioManager.Instance.StopAudio(AudioPlayerType.Sfx);
        GetTree().ChangeSceneToPacked(scene);
        EventCenterManager.Instance.RemoveAllListeners<GameStartEvent>();
        UiManager.Instance.FadeOut();
    }
}
