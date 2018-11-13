using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class editorwindowtest : EditorWindow
{

    private void OnGUI()
    {

    }

    [MenuItem("MyMenu/Open Test Window %g")]
    static void DoSomethingWithAShortcutKey()
    {
        EditorWindow.GetWindow<editorwindowtest>();
    }



    [MenuItem("MyMenu/Open Test Win %g+%g")]
    static void CloseWindow()

    {
        if (
        EditorWindow.GetWindow<editorwindowtest>() != null)
        {

            EditorWindow.GetWindow<editorwindowtest>().Close();
        }

    }

 
}
