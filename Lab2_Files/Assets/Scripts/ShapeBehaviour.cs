using UnityEngine;

// Base class for any resizable shape that the shared custom editor can operate on
public abstract class ShapeBehaviour : MonoBehaviour
{
    [SerializeField] protected float size = 1f;

    // Name shown in the editor buttons
    public abstract string ShapeName { get; }

    // Returns a warning message if the current size is invalid, or null if it's fine
    public abstract string GetSizeWarning();
}