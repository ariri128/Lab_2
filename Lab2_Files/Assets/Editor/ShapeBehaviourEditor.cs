using UnityEngine;
using UnityEditor;

// Shared inspector for all ShapeBehaviour subclasses
[CustomEditor(typeof(ShapeBehaviour), true), CanEditMultipleObjects]
public class ShapeBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var shape = (ShapeBehaviour)target;
        var sizeProperty = serializedObject.FindProperty("size");

        EditorGUILayout.PropertyField(sizeProperty);

        string warning = shape.GetSizeWarning();
        if (!string.IsNullOrEmpty(warning))
        {
            EditorGUILayout.HelpBox(warning, MessageType.Warning);
        }

        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.Space();

        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button($"Select all {shape.ShapeName.ToLower()}s"))
            {
                var allOfType = GameObject.FindObjectsByType(target.GetType(), FindObjectsInactive.Include, FindObjectsSortMode.None);
                var allGameObjects = new Object[allOfType.Length];
                for (int i = 0; i < allOfType.Length; i++)
                {
                    allGameObjects[i] = ((Component)allOfType[i]).gameObject;
                }
                Selection.objects = allGameObjects;
            }

            if (GUILayout.Button("Clear selection"))
            {
                Selection.objects = new Object[0];
            }
        }

        var allShapesOfType = GameObject.FindObjectsByType(target.GetType(), FindObjectsInactive.Include, FindObjectsSortMode.None);

        bool anyEnabled = false;
        foreach (var obj in allShapesOfType)
        {
            if (((Component)obj).gameObject.activeSelf) { anyEnabled = true; break; }
        }

        var cachedColor = GUI.backgroundColor;
        GUI.backgroundColor = anyEnabled ? Color.green : Color.red;

        if (GUILayout.Button($"Disable/Enable all {shape.ShapeName.ToLower()}s", GUILayout.Height(30)))
        {
            foreach (var obj in allShapesOfType)
            {
                var go = ((Component)obj).gameObject;
                Undo.RecordObject(go, "Toggle " + shape.ShapeName);
                go.SetActive(!go.activeSelf);
            }
        }

        GUI.backgroundColor = cachedColor;
    }
}