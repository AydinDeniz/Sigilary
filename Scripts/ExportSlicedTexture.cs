using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class ExportSlicedTexture : EditorWindow
{
    
    private Texture2D texture;
    private string name1;
    [MenuItem("Window/Export Sliced Texture")]
    public static void ShowWindow()
    {
        GetWindow<ExportSlicedTexture>("Export Sliced Texture");
    }

    private void OnGUI()
    {
        texture = (Texture2D)EditorGUILayout.ObjectField(texture, typeof(Texture2D), allowSceneObjects: false);
        name1 = EditorGUILayout.TextField("File name: ", name1);
        if (GUILayout.Button("Run Function") && texture != null)
        {
            SaveTextureAsPNG(texture, name1);
        }
    }

    public static void SaveTextureAsPNG(Texture2D texture, string fileName)
    {
        byte[] _bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/Sprite Sheets/";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllBytes(dirPath + fileName + ".png", _bytes);
        Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + fileName + ".png");
    }
    
}
#endif