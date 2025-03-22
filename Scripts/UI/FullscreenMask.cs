using Godot;
using LumiVerseFramework.Managers;
using O342025.Scripts.Managers;

namespace O342025.Scripts.UI;

public partial class FullscreenMask : CanvasLayer
{
    [Signal]
    public delegate void FadeInCompletedEventHandler();

    [Signal]
    public delegate void FadeInStartEventHandler();

    [Signal]
    public delegate void FadeOutCompletedEventHandler();

    [Signal]
    public delegate void FadeOutStartEventHandler();

    [ExportGroup("节点依赖")] [Export] private AnimationTree _animationTree;

    public override void _Ready()
    {
        base._Ready();
        // 初始化动画
        _animationTree = GetNode<AnimationTree>("FullScreenMask/AnimationTree");
        _animationTree.Set("parameters/conditions/FadeIn", false);
        _animationTree.Set("parameters/conditions/FadeOut", false);
        // 初始化信号
        FadeInStart += () =>
        {
            EventCenterManager.Instance.TriggerEvent<GameStartEvent>(
                new GameStartEvent { Ready = false });
        };
        FadeOutCompleted += () =>
        {
            EventCenterManager.Instance.TriggerEvent<GameStartEvent>(
                new GameStartEvent { Ready = true });
        };
    }

    /// <summary>
    /// 淡出
    /// </summary>
    public void FadeIn()
    {
        _animationTree.Set("parameters/conditions/FadeOut", false);
        _animationTree.Set("parameters/conditions/FadeIn", true);
    }

    /// <summary>
    /// 淡入
    /// </summary>
    public void FadeOut()
    {
        _animationTree.Set("parameters/conditions/FadeIn", false);
        _animationTree.Set("parameters/conditions/FadeOut", true);
    }

    private async void EmitFadeInCompleted()
    {
        EmitSignal(SignalName.FadeInCompleted);
    }

    private void EmitFadeOutCompleted()
    {
        EmitSignal(SignalName.FadeOutCompleted);
    }

    private void EmitFadeInStart()
    {
        EmitSignal(SignalName.FadeInStart);
    }

    private void EmitFadeOutStart()
    {
        EmitSignal(SignalName.FadeOutStart);
    }
}
