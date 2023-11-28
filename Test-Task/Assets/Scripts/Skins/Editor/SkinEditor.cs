using UnityEditor;
using UnityEngine;

namespace Skins.Editor
{
    [CustomEditor(typeof(Skin))]
    public class SkinEditor : UnityEditor.Editor
    {
        private bool dropdown;
        
        SerializedProperty offsetProp;
        SerializedProperty materialProp;
        SerializedProperty stringArrayProp;
        SerializedProperty arrayLengthProp;


        void OnEnable()
        {
            materialProp = serializedObject.FindProperty("material");
            arrayLengthProp = serializedObject.FindProperty("size");
            stringArrayProp = serializedObject.FindProperty("daysName");
            offsetProp = serializedObject.FindProperty("offset");

        }
        
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Skin Setup", EditorStyles.boldLabel);
            DrawUILine(Color.gray, 1, 2);

            EditorGUI.indentLevel++;
            
            EditorGUILayout.PropertyField(materialProp, new GUIContent("Sec Hand Material"));

            GUILayout.Space(10);

            dropdown = EditorGUILayout.Foldout(dropdown, "Day Names");
            if (dropdown)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(arrayLengthProp);

                stringArrayProp.arraySize = arrayLengthProp.intValue;

                for (int i = 0; i < stringArrayProp.arraySize; i++)
                {
                    EditorGUILayout.PropertyField(stringArrayProp.GetArrayElementAtIndex(i), new GUIContent("Element " + i));
                }
                EditorGUI.indentLevel--;
            }
            
            GUILayout.Space(10);

            EditorGUILayout.IntSlider(offsetProp, -12, 12, new GUIContent("Offset"));

            //EditorGUILayout.PropertyField(offsetProp, new GUIContent("Sec Hand Material"));
            
            EditorGUI.indentLevel--;
            
            GUILayout.Space(20);

            if (arrayLengthProp.intValue != 7)
            {
                EditorGUILayout.HelpBox($"Week must have 7 days, you have {arrayLengthProp.intValue}", MessageType.Error);
            }
            
            serializedObject.ApplyModifiedProperties();
        }
        
        private static void DrawUILine(Color color, int thickness = 2, int padding = 10)
        {
            Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
            r.height = thickness;
            r.y += padding / 2;
            r.x -= 2;
            r.width += 6;
            EditorGUI.DrawRect(r, color);
        }
    }
}