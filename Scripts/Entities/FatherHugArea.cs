using Godot;
using LumiVerseFramework.Common;

namespace O342025.Scripts.Entities;

public partial class FatherHugArea : Area2D
{
    [Export] private AnimationPlayer _animationPlayer;
    
    private void OnBodyEntered(Node2D body)
    {
        YumihoshiDebug.Print<FatherHugArea>("测试", "玩家进入父亲拥抱区域");
        (body as Player.Player).AllowMove = false;
        _animationPlayer.Play("Hug");
        QueueFree();
    }
}
