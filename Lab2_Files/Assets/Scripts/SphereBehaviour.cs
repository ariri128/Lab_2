using UnityEngine;

// Sphere shape: enforces a minimum radius and keeps the transform's scale in sync
public class SphereBehaviour : ShapeBehaviour
{
    public override string ShapeName => "Sphere";
    
    // Called by the editor when this component is first added (or manually reset)
    private void Reset()
    {
        size = 0.5f;
    }

    public override string GetSizeWarning()
    {
        return size < 0.5f ? "The spheres' radius cannot be smaller than 0.5!" : null;
    }

    // Called automatically whenever a serialized field is changed in the Inspector
    private void OnValidate()
    {
        transform.localScale = Vector3.one * size * 2f; // Diameter = 2 * radius
    }
}