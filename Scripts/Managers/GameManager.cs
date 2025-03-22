using Godot;
using LumiVerseFramework.Base;
using LumiVerseFramework.Managers;

namespace O342025.Scripts.Managers;

public partial class GameManager : Singleton<GameManager>
{
    // TODO: 音频bug，全屏渐变后游戏逻辑才开始
    
    private bool _gameReady;
}

public class GameStartEvent
{
    public bool Ready { get; set; }
}
