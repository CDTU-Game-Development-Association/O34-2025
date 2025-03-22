using Godot;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Entities;

public partial class Water : Area2D
{
    [Export] private AnimationPlayer _ani;
    [Export] private string _curScene;

    private void OnBodyEntered(Node2D body)
    {
        _ani.Stop();
        SceneManager.Instance.LoadScene(_curScene);
    }
}
