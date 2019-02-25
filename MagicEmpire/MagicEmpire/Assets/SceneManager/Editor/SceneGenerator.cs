using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;
using Scene = UnityEngine.SceneManagement.Scene;


[InitializeOnLoad]
public class SceneGenerator
{
	static SceneGenerator()
	{
		EditorSceneManager.newSceneCreated += SceneCreating;	    
	} 
	public static void SceneCreating(Scene scene, NewSceneSetup setup, NewSceneMode mode)
	{
		if (Camera.main == null) return;
		var camGO = Camera.main.gameObject;
		var light = GameObject.Find("Directional Light");
		if (light != null)
		{
			GameObject.DestroyImmediate(light.gameObject);
		}
		var setupGO = new GameObject("[SETUP]");
		var sceneGO = new GameObject("[SCENE]");
		var dynamic = new GameObject("Dynamic");
		dynamic.transform.parent = sceneGO.transform;
		camGO.transform.parent = setupGO.transform;
		Debug.Log("New scene created!");
 
	}
}