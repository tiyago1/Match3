using UnityEngine;
using UnityEditor;
using System.IO;

public class ScriptableObjectUtility : MonoBehaviour 
{
    public static void CreateLevelAsset<T>() where T : ScriptableObject
    {
        T level = ScriptableObject.CreateInstance<T>();
        string path = AssetDatabase.GenerateUniqueAssetPath("Assets/" + typeof(T).Name + ".asset");

        AssetDatabase.CreateAsset(level, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
    }
}
