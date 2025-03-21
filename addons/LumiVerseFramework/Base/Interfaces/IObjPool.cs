// *****************************************************************************
// @author: 绘星tsuki
// @email: xiaoyuesun915@gmail.com
// @creationDate: 2025/03/06 17:03
// @version: 1.0
// @description:
// *****************************************************************************

using Godot;

namespace LumiVerseFramework.Base.Interfaces;

public interface IObjPool
{
    public void Enable()
    {
        if (this is Node node)
            node.ProcessMode = Node.ProcessModeEnum.Inherit;
        if (this is Node2D node2D)
            node2D.Visible = true;
    }

    public void Disable()
    {
        if (this is Node2D node2D)
            node2D.Visible = false;
        if (this is Node node)
            node.ProcessMode = Node.ProcessModeEnum.Disabled;
    }
}
