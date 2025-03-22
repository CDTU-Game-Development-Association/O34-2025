using System;
using Godot;
using LumiVerseFramework.Async;
using LumiVerseFramework.Base;
using LumiVerseFramework.Common;
using LumiVerseFramework.Managers;
using O342025.Scripts.UI;

namespace O342025.Scripts.Managers;

public partial class SceneManager : Singleton<SceneManager>
{
    private FullscreenMask _fullscreenMask;

    private string _scenePath;
    private bool _stopBgm;
    private bool _stopEnvironment;
    private float _timer;
    private bool _enableTimer;

    public override void _Ready()
    {
        base._Ready();
        UiManager.Instance.FullscreenMaskNode.FadeInCompleted +=
            HandleLoadScene;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!_enableTimer) return;
        _timer += (float)delta;
    }

    /// <summary>
    /// 切换场景
    /// </summary>
    /// <param name="scenePath"></param>
    /// <param name="stopBgm"></param>
    /// <param name="stopEnvironment"></param>
    public void LoadScene(string scenePath, bool stopBgm = false,
        bool stopEnvironment = true)
    {
        _scenePath = scenePath;
        _stopBgm = stopBgm;
        _stopEnvironment = stopEnvironment;
        UiManager.Instance.FadeIn();
    }

    private async void HandleLoadScene()
    {
        try
        {
            // 启动异步加载
            ResourceLoader.LoadThreadedRequest(_scenePath, "PackedScene", true);
            _enableTimer = true;
            while (ResourceLoader.LoadThreadedGetStatus(_scenePath) !=
                   ResourceLoader.ThreadLoadStatus.Loaded)
            {
                // 加载失败，重新加载
                if (ResourceLoader.LoadThreadedGetStatus(_scenePath) ==
                    ResourceLoader.ThreadLoadStatus.Failed)
                    ResourceLoader.LoadThreadedRequest(_scenePath,
                        "PackedScene", true);
                // 5s超时，重新加载
                if (_timer > 5f)
                {
                    ResourceLoader.LoadThreadedRequest(_scenePath,
                        "PackedScene", true);
                    _timer = 0f;
                    _enableTimer = true;
                }

                await WaitTask.WaitForNextFrame(this);
            }

            _enableTimer = false;
            
            // 加载完成，切换场景
            var scene =
                ResourceLoader.LoadThreadedGet(_scenePath) as PackedScene;
            if (_stopBgm)
                AudioManager.Instance.StopAudio(AudioPlayerType.Bgm);
            if (_stopEnvironment)
                AudioManager.Instance.StopAudio(AudioPlayerType.Environment);
            AudioManager.Instance.StopAudio(AudioPlayerType.Sfx);
            EventCenterManager.Instance.RemoveAllListeners<GameStartEvent>();
            GetTree().ChangeSceneToPacked(scene);
            UiManager.Instance.FadeOut();
        }
        catch (Exception)
        {
            YumihoshiDebug.Error<SceneManager>("场景切换", "切换场景失败");
            CallDeferred(nameof(Fallback));
        }
    }

    private void Fallback()
    {
        GetTree().ChangeSceneToFile(_scenePath);
    }
}
