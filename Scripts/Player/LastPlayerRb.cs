using Godot;
using O342025.Scripts.Base;

namespace O342025.Scripts.Player;

public partial class LastPlayerRb : BasicPlayer
{
    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        for (var i = 0; i < GetSlideCollisionCount(); i++)
        {
            KinematicCollision2D collision = GetSlideCollision(i);
            if (collision.GetCollider() is RigidBody2D rb)
            {
                rb.ApplyCentralImpulse(-collision.GetNormal() * 20f);
            }
        }
    }
}
