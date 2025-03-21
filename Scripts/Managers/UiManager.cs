using Godot;
using LumiVerseFramework.Base;
using LumiVerseFramework.Common;
using O342025.Scripts.UI;

namespace O342025.Scripts.Managers;

public partial class UiManager : Singleton<UiManager>
{
    private PackedScene _fullscreenMaskScene;
    public FullscreenMask FullscreenMaskNode { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        _fullscreenMaskScene =
            GD.Load<PackedScene>(
                "res://Scenes/UI/FullscreenMaskWithCanvas.tscn");
        CheckFullscreenMaskNode();
    }

    public void FadeIn()
    {
        CheckFullscreenMaskNode();
        FullscreenMaskNode.FadeIn();
    }

    public void FadeOut()
    {
        CheckFullscreenMaskNode();
        FullscreenMaskNode.FadeOut();
    }

    /// <summary>
    /// 检查全屏遮罩节点，如果不存在则创建
    /// </summary>
    private void CheckFullscreenMaskNode()
    {
        YumihoshiDebug.Print<UiManager>("检查全屏遮罩节点",
            "组内个数:" + GetTree().GetNodeCountInGroup("FullScreenMask"));
        if (GetTree().GetNodeCountInGroup("FullScreenMask") == 0)
        {
            FullscreenMaskNode =
                _fullscreenMaskScene.Instantiate<FullscreenMask>();
            GetTree().Root.AddChild(FullscreenMaskNode);
        }
        else
        {
            FullscreenMaskNode =
                GetTree()
                    .GetNodesInGroup("FullScreenMask")[0] as FullscreenMask;
        }
    }
}
