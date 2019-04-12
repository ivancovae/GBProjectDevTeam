using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


[InitializeOnLoad]
public class SceneGenerator
{
    static SceneGenerator() 
    {
        EditorSceneManager.newSceneCreated += SceneCreating;
    }

    public static void SceneCreating(Scene scene, NewSceneSetup setup, NewSceneMode mode) 
    {
        var camGO = Camera.main.transform;
        //для 3d проекта, нужно сразу перемещать свет
        //var lightGO = GameObject.Find("Directional Light").transform;

        var setupFolder = new GameObject("[SETUP]").transform;

        var lightsFolder = new GameObject("Lights").transform;
        lightsFolder.parent = setupFolder;
        //lightGO.parent = lightsFolder;

        var camerasFolder = new GameObject("Cameras").transform;
        camGO.parent = camerasFolder;
        camerasFolder.parent = setupFolder;

        var worldFolder = new GameObject("[WORLD]").transform;
        new GameObject("Static").transform.parent = worldFolder;
        new GameObject("Dynamic").transform.parent = worldFolder;

        var uiFolder = new GameObject("[UI]").transform;

        Debug.Log("New scene created!");
    }
}
