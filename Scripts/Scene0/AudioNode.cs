using Godot;

namespace O342025.Scripts.Scene0;

public partial class AudioNode : Node
{
    [Export] public AudioStreamPlayer BgmPlayer { get; private set; }
    [Export] public AudioStreamPlayer SfxPlayer { get; private set; }
    [Export] public AudioStreamPlayer EnvironmentPlayer { get; private set; }
}
