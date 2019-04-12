using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Interface;
using Games.Helpers;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Games.Controller
{
	[System.Serializable] public class UnityEventProgress<T>:UnityEvent<T, float> where T : ControllerBase {}

	[System.Serializable]
	public class GameplayScenes {
		public SceneField GlobalScene;
		public List<SceneField> LevelScenes;
	}

    [CreateAssetMenu(fileName = "ControllerScenes", menuName = "Controllers/ControllerScenes")]
	public class ControllerScenes : ControllerBase, IAwake 
	{
		public SceneField loadScene;
		public GameplayScenes scenes = new GameplayScenes();

		private SceneField _currentScene;
		public SceneField CurrentScene => _currentScene;

		public UnityEventController<ControllerScenes> OnStartLoadScene;
		public UnityEventProgress<ControllerScenes> OnProgressLoadScene;
		public UnityEventController<ControllerScenes> OnEndLoadScene;

		public void OnAwake()
		{
			GameObject.Find("[SETUP]").AddComponent<ScenesControllerComponent>().Setup(this);	

			//_currentScene = SceneManager.GetActiveScene();

			OnStartLoadScene = new UnityEventController<ControllerScenes>();
			OnProgressLoadScene = new UnityEventProgress<ControllerScenes>();
			OnEndLoadScene = new UnityEventController<ControllerScenes>();
		}
	}
}