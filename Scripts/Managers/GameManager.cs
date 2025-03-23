using LumiVerseFramework.Base;

namespace O342025.Scripts.Managers;

public partial class GameManager : Singleton<GameManager>
{
    private bool _gameReady;
    public int SecretCount { get; set; }
}

public class GameStartEvent
{
    public bool Ready { get; set; }
}
