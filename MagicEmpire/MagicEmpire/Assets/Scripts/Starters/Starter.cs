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
		public List<SceneField> ScenesToKeep;
		public List<SceneField> SceneDependsOn;

		public void BindScene()
		{
			Setup();
			Initialized = true;
		}

		protected virtual void Setup() {}

		protected virtual void OnDestroy() { Initialized = false; }

		public List<ControllerBase> controllers = new List<ControllerBase>();

		void Awake()
		{
			foreach (var controllerBase in controllers)
			{
				Toolbox.Add(controllerBase);
			}
		}
    }
}