using Godot;
using O342025.Scripts.Base;

namespace O342025.Scripts.Scene7;

public partial class LastPlatform : Area2D
{
    [Export] private BasicPlayer _player;

    private void OnBodyEntered(Node2D body)
    {
        _player.AllowMove = false;
    }
}
