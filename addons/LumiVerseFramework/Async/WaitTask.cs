// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/06 16:03
// @version: 1.0
// @description:
// *****************************************************************************

using System.Threading.Tasks;
using Godot;

namespace LumiVerseFramework.Async;

public class WaitTask
{
    /// <summary>
    /// 等待下一帧
    /// </summary>
    /// <param name="node"></param>
    public static async Task WaitForNextFrame(Node node)
    {
        await node.ToSignal(node.GetTree(),
            SceneTree.SignalName.ProcessFrame);
    }

    /// <summary>
    /// 等待一个物理帧
    /// </summary>
    public static async Task WaitForPhysicsFrame(Node node)
    {
        await node.ToSignal(node.GetTree(),
            SceneTree.SignalName.PhysicsFrame);
    }

    /// <summary>
    /// 等待秒
    /// </summary>
    /// <param name="node"></param>
    /// <param name="seconds"></param>
    public static async Task WaitForSeconds(Node node, float seconds)
    {
        SceneTreeTimer timer = node.GetTree().CreateTimer(seconds);
        await node.ToSignal(timer, "timeout");
    }
}
