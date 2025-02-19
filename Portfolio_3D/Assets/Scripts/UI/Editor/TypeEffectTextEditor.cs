using System;
using UnityEditor;
using UnityEngine;
using TextEditor = UnityEditor.UI.TextEditor;

namespace UI.Editor
{
    [CustomEditor(typeof(TypeEffectText), true)]
    public class TypeEffectTextEditor : TextEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var term = serializedObject.FindProperty("typeTerm").floatValue;
            var newTerm = EditorGUILayout.Slider("Type Term", term, 0f, 1f);
            if (Math.Abs(newTerm - term) > 0.01f)
            {
                serializedObject.FindProperty("typeTerm").floatValue = newTerm;
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}