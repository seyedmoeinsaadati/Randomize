using UnityEngine;
using UnityEditor;

public class RandomSelectEditor : EditorWindow
{
    public float percent;
    [MenuItem("Tools/Random Select &T", false, 10)]
    public static void ShowWindow()
    {
        GetWindow<RandomSelectEditor>("Random Select Window", true);
    }

    void OnGUI()
    {

        GUILayout.Label("Options:");
        GUILayout.Space(1f);

        percent = EditorGUILayout.FloatField("Object Persent (0 to 1): ", percent, GUILayout.ExpandWidth(true));
        if (percent > 1)
        {
            percent = 1;
        }
        if (percent < 0)
        {
            percent = 0;
        }

        GUILayout.Space(1f);
        if (GUILayout.Button("Select Random Objects"))
        {
            SelectRandomObject();
        }
    }

    void SelectRandomObject()
    {
        Transform[] trans = Selection.GetTransforms(SelectionMode.TopLevel);

        int count = (int)(percent * trans.Length);
        Debug.Log(count);
        GameObject[] selectedObjects = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            int rindex = (int)Random.Range(0, trans.Length);
            while (trans[rindex] == null)
                rindex = (int)Random.Range(0, trans.Length);
            selectedObjects[i] = trans[rindex].gameObject;
            trans[rindex] = null;
        }

        Selection.objects = selectedObjects;
        Debug.Log(count + " objects selected.");
    }

    public static bool isRandomable()
    {
        return Selection.gameObjects.Length > 0;
    }


}