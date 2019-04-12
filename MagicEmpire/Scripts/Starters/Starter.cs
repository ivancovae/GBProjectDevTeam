using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Controller;
using Games.Helpers;

namespace Games
{
	public class Starter : MonoBehaviour
    {
		public static bool Initialized;

        public List<ControllerBase> Controllers;
		public List<SceneField> ScenesToKeep;
		public List<SceneField> SceneDependsOn;

	    void Awake()
		{
            ProcessingScene.Dynamic = GameObject.Find("Dynamic").transform;

            if (ProcessingUpdate.Default == null)
            {
                ProcessingUpdate.Create();
            }

            ProcessingSceneLoad.Default.Setup(ScenesToKeep, SceneDependsOn, this);
        }

		public void BindScene()
		{
            foreach (var controller in Controllers)
			{
				Toolbox.Add(controller);
            }
			Setup();
			Initialized = true;
		}

        protected static T Add<T>() where T : new() { return Toolbox.Add<T>(); }

		protected virtual void Setup() {}

		protected virtual void OnDestroy() { Initialized = false; }
    }
}