using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class LevelEditor : EditorWindow
{
    public static int LevelNumber;
    public static int MoveCounter;

    public static int FirstStarGoalAmmount;
    public static int SecondStarGoalAmmount;
    public static int ThirdStarGoalAmmount;

    [MenuItem("Level Designer/Create Level")]
    public static void Initalize()
    {
        LevelEditor LevelDesiggner = (LevelEditor)GetWindow(typeof(LevelEditor));
        LevelDesiggner.Show();
    }

    public static void CreateLevelAsset(Level assest) 
    {
        string path = AssetDatabase.GenerateUniqueAssetPath("Assets/Levels/"  + "Level "  + LevelNumber + ".asset");
        
        AssetDatabase.CreateAsset(assest, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = assest;
    }

    public void Save()
    {
        Level level = new Level();        
        
        level.LevelNumber = LevelNumber;
        level.MoveCounter = MoveCounter;

        level.FirstStarGoalAmmount = FirstStarGoalAmmount;
        level.SecondStarGoalAmmount = SecondStarGoalAmmount;
        level.ThirdStarGoalAmmount = ThirdStarGoalAmmount;

        CreateLevelAsset(level);
    }

    private void OnGUI()
    {
        GUILayout.Label("Hello Level Editor !");

        LevelNumber = EditorGUILayout.IntField("Level Number : ",LevelNumber);
        MoveCounter = EditorGUILayout.IntField("Move Counter : ", MoveCounter);

        FirstStarGoalAmmount   = EditorGUILayout.IntField("1 st : ", FirstStarGoalAmmount);
        SecondStarGoalAmmount  = EditorGUILayout.IntField("2 nt : ", SecondStarGoalAmmount);
        ThirdStarGoalAmmount   = EditorGUILayout.IntField("3 rt : ", ThirdStarGoalAmmount);

        if (GUILayout.Button("Save Level"))
        {
            Save();
        }
    }
}
