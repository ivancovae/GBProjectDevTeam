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

        
    }
}
