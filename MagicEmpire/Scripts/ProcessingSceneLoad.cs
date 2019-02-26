using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Games.Helpers;
using Games.Interface;
using UnityEngine.SceneManagement;

namespace Games
{
    public class ProcessingSceneLoad
    {
        public static ProcessingSceneLoad Default = new ProcessingSceneLoad();

        private List<string> scenesToKeep = new List<string>();
        private List<string> sceneDependsOn = new List<string>();

        private Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();

        public Action SceneLoaded = delegate {};
        public Action SceneClosing = delegate {};

        public void Setup(List<SceneField> sceneToKeep, List<SceneField> sceneDependsOn, Starter starter)
        {
            this.scenesToKeep.Clear();
            this.sceneDependsOn.Clear();

            for (var i = 0; i < scenesToKeep.Count; i++)
            {
                this.scenesToKeep.Add(sceneToKeep[i].SceneName);
            }
            for (var i = 0; i < sceneDependsOn.Count; i++)
            {
                this.sceneDependsOn.Add(sceneDependsOn[i].SceneName);
            }
            Toolbox.Instance.StartCoroutine(_Setup(starter));
        }
        private IEnumerator _Setup(Starter starter)
        {
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                scenes.Add(scene.name, scene);
            }

            for (var i = 0; i < sceneDependsOn.Count; i++)
            {
                var name = sceneDependsOn[i];
                if (scenes.ContainsKey(name))
                {
                    yield return new WaitForSeconds(0.1f);
                    continue;
                }

                var load = SceneManager.LoadSceneAsync(sceneDependsOn[i], LoadSceneMode.Additive);
                while (!load.isDone)
                {
                    yield return 0;
                }

                scenes.Add(name, SceneManager.GetSceneByName(name));
            }

            SceneLoaded();
            starter.BindScene();
        }

        IEnumerator _Load(string name)
		{
			SceneClosing();
			Toolbox.ChangingScene = true;
			
			var s     = SceneManager.GetActiveScene();
			var sName = s.name;

			var job = SceneManager.UnloadSceneAsync(s);

			while (!job.isDone)
			{
				yield return 0;
			}

			scenes.Remove(sName);
			foreach (var key in scenes.Keys)
			{
				if (scenesToKeep.Contains(key)) continue;
				job = SceneManager.UnloadSceneAsync(scenes[key]);

				while (!job.isDone)
				{
					yield return 0;
				}
			}

			job = Resources.UnloadUnusedAssets();
			while (!job.isDone)
			{
				yield return 0;
			}

			scenes.Clear();
			job = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
			while (!job.isDone)
			{
				yield return 0;
			}

			SceneManager.SetActiveScene(SceneManager.GetSceneByName(name));
			job.allowSceneActivation = true;
			Toolbox.ChangingScene = false;
		}

		IEnumerator _Load(int id)
		{
			SceneClosing();
			Toolbox.ChangingScene = true;
			Toolbox.Instance.ClearSessionData();

			var s     = SceneManager.GetActiveScene();
			var sName = s.name;

			var job = SceneManager.UnloadSceneAsync(s);

			while (!job.isDone)
			{
				yield return 0;
			}

			scenes.Remove(sName);
			foreach (var key in scenes.Keys)
			{
				if (scenesToKeep.Contains(key)) continue;

				job = SceneManager.UnloadSceneAsync(scenes[key]);

				while (!job.isDone)
				{
					yield return 0;
				}
			}

			job = Resources.UnloadUnusedAssets();
			while (!job.isDone)
			{
				yield return 0;
			}

			scenes.Clear();

			job = SceneManager.LoadSceneAsync(id, LoadSceneMode.Additive);
			while (!job.isDone)
			{
				yield return 0;
			}

			SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(id));
			job.allowSceneActivation = true;
			Toolbox.ChangingScene = false;
		}

		public static void Add(int id) { Toolbox.Instance.StartCoroutine(_Add(id)); }

		public static void Remove(int id) { Toolbox.Instance.StartCoroutine(_Remove(id)); }

		static IEnumerator _Add(int id)
		{
			Toolbox.ChangingScene = true;
			SceneManager.sceneLoaded += OnAdditiveLoaded;
			var job = SceneManager.LoadSceneAsync(id, LoadSceneMode.Additive);
			while (!job.isDone)
			{
				yield return 0;
			}

			Toolbox.ChangingScene = false;
		}

		private static void OnAdditiveLoaded(Scene arg0, LoadSceneMode arg1)
		{
			if (arg1 != LoadSceneMode.Additive) return;

			SceneManager.sceneLoaded -= OnAdditiveLoaded;
	//		Toolbox.Instance.StartCoroutine(_OnAdditiveLoaded(arg0));
		}

		static IEnumerator _OnAdditiveLoaded(Scene arg)
		{
//			var roots = arg.GetRootGameObjects();
//			var list  = new List<Actor>(10);
//
//
//			foreach (var o in roots)
//				list.AddRange(o.transform.GetAll<Actor>());


//			var len = list.Count;
//			if (len == 0) yield break;


//			while (true)
//			{
//				for (int i = 0; i < len; i++)
//				{
//					while (true)
//					{
//						if (list[i].state.initialized)
//							break;
//						yield return 0;
//					}
//				}
//
//				break;
//			}

//			for (int i = 0; i < len; i++)
//			{
//				ProcessingEntities.Default.CheckGroups(list[i].entity, true);
//			}
			yield break;
		}


		static IEnumerator _Remove(int id)
		{
			Toolbox.ChangingScene = true;
			var job = SceneManager.UnloadSceneAsync(id);
			while (!job.isDone)
			{
				yield return 0;
			}

			Toolbox.ChangingScene = false;
		}


		public static void To(int id)
		{
			var processing = Default;

			Toolbox.Instance.StartCoroutine(processing._Load(id));
		}

		public static void To(string name)
		{
			var processing = Default;
			Toolbox.Instance.StartCoroutine(processing._Load(name));
		}
    }
}
