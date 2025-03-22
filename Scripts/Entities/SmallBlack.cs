using Godot;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Entities;

public partial class SmallBlack : Area2D
{
    [Export] private string _curScene;
    [Export] private AnimationPlayer _ani;
    
    private void OnBodyEntered(Node2D body)
    {
        _ani.Stop();
        SceneManager.Instance.LoadScene(_curScene);
        QueueFree();
    }
}
