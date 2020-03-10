using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LevelArrayStats))]
public class LayoutInspectorStats : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);
        EditorGUI.PrefixLabel(position, label);
        Rect newPosition = position;
        newPosition.y += 18f;
        SerializedProperty data = property.FindPropertyRelative("levellist");

        for (int j = 0; j < 25; j++)
        {
            SerializedProperty row = data.GetArrayElementAtIndex(j).FindPropertyRelative("level");
            if (row.arraySize != 25) row.arraySize = 25;
            newPosition.width = position.width / 25;
            newPosition.height = 25f;
            for (int i = 0; i < 25; i++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(i), GUIContent.none);
                newPosition.x += newPosition.width;
            }
            newPosition.x = position.x;
            newPosition.y += 15f;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //return base.GetPropertyHeight(property, label);
        return 16f * 26;
    }
}


