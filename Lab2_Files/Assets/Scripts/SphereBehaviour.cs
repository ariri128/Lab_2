using UnityEngine;

// Sphere shape: enforces a minimum radius and keeps the transform's scale in sync
public class SphereBehaviour : ShapeBehaviour
{
    public override string ShapeName => "Sphere";

    public override string GetSizeWarning()
    {
        return size < 1f ? "The spheres' radius cannot be smaller than 1!" : null;
    }

    private void Update()
    {
        transform.localScale = Vector3.one * size * 2f; // Diameter = 2 * radius
    }
}