using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Skin))]
    public class SkinEditor : UnityEditor.Editor
    {
        private bool dropdown;
        SerializedProperty stringArrayProp;
        SerializedProperty arrayLengthProp;

        void OnEnable()
        {
            stringArrayProp = serializedObject.FindProperty("daysName");
            arrayLengthProp = serializedObject.FindProperty("size");
        }
        
        public override void OnInspectorGUI()
        {
            Skin skin = (Skin)target;
            EditorGUILayout.LabelField("Skin Setup", EditorStyles.boldLabel);
            DrawUILine(Color.gray, 1, 2);

            EditorGUI.indentLevel++;
            
            skin.material = (Material)EditorGUILayout.ObjectField("Sec Hand Material", skin.material, typeof(Material), false);
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

            skin.offset = EditorGUILayout.IntSlider(new GUIContent("Offset", "Description of Offset"), skin.offset, -12, 12);
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