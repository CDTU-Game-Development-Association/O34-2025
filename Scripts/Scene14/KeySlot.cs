using Godot;
using LumiVerseFramework.Common;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Scene14;

public partial class KeySlot : Area2D
{
    [Export] private AnimationPlayer _ani;
    
    private void OnBodyEntered(Node2D body)
    {
        _ani.Stop();
        _ani.Play("Second");
        body.QueueFree();
        QueueFree();
    }
}
