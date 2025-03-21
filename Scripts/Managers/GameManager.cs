using Godot;
using LumiVerseFramework.Base;

namespace O342025.Scripts.Managers;

public partial class GameManager : Singleton<GameManager>
{
    [Signal]
    public delegate void OnGameReadyEventHandler();
    // TODO: 音频bug，全屏渐变后游戏逻辑才开始

    public bool GameReady
    {
        get => _gameReady;
        set
        {
            _gameReady = value;
            if (value) EmitSignal(SignalName.OnGameReady);
        }
    }

    private bool _gameReady;

    public override void _Ready()
    {
        base._Ready();
        UiManager.Instance.FullscreenMaskNode.FadeOutCompleted +=
            () => GameReady = true;
        UiManager.Instance.FullscreenMaskNode.FadeInStart +=
            () => GameReady = false;
    }
}
