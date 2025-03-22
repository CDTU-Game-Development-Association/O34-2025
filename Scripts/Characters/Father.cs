using Godot;
using O342025.Scripts.Base;
using O342025.Scripts.Managers;

namespace O342025.Scripts.Characters;

public partial class Father : BasicPlayer
{
    private void OnBodyEntered(Node body)
    {
        ReloadCurScene();
    }

    private void ReloadCurScene()
    {
        SceneManager.Instance.LoadScene("res://Scenes/Root/Scene6.tscn");
    }
}
