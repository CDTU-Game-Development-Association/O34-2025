using LumiVerseFramework.Base;
using O342025.Scripts.UI;

namespace O342025.Scripts.Managers;

public partial class UiManager : Singleton<UiManager>
{
    public FullscreenMask FullscreenMaskNode { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        FullscreenMaskNode =
            GetTree().GetFirstNodeInGroup("FullScreenMask") as FullscreenMask;
    }

    public void FadeIn()
    {
        FullscreenMaskNode.FadeIn();
    }

    public void FadeOut()
    {
        FullscreenMaskNode.FadeOut();
    }
}
