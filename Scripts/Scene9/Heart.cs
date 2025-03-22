using Godot;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene9;

public partial class Heart : Area2D
{
    [Export] private string _nextScenePath;
    
    private void OnBodyEntered(Node2D body)
    {
        SceneManager.Instance.LoadScene(_nextScenePath);
    }
}
