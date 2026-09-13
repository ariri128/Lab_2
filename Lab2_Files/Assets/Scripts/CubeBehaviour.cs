using UnityEngine;

// Cube shape: enforces a maximum size and keeps the transform's scale in sync
public class CubeBehaviour : ShapeBehaviour
{
    public override string ShapeName => "Cube";

    public override string GetSizeWarning()
    {
        return size > 2f ? "The cubes' sizes cannot be bigger than 2!" : null;
    }

    private void Update()
    {
        transform.localScale = Vector3.one * size;
    }
}