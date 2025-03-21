using LumiVerseFramework.Base;
using O342025.Scripts.UI;

namespace O342025.Scripts.Managers;

public partial class SceneManager : Singleton<SceneManager>
{
    private FullscreenMask _fullscreenMask;

    private string _scenePath;

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
    public void LoadScene(string scenePath)
    {
        _scenePath = scenePath;
        UiManager.Instance.FadeIn();
    }

    private void HandleLoadScene()
    {
        GetTree().ChangeSceneToFile(_scenePath);
        UiManager.Instance.FadeOut();
    }
}
