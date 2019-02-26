using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Games.Controller
{
    public class ScenesControllerComponent : MonoBehaviour
    {
        private ControllerScenes controller;

        public void Setup(ControllerScenes controller)
        {
            this.controller = controller;
        }

#region LoadScene
		public void LoadSceneAsync(int lvl)
		{
			AsyncOperation async = SceneManager.LoadSceneAsync(lvl);
			StartCoroutine(LoadSceneAsync(async));
		}
		public void LoadSceneAsync(Scene lvl)
		{
			AsyncOperation async = SceneManager.LoadSceneAsync(lvl.buildIndex);
			StartCoroutine(LoadSceneAsync(async));
		}
		public void LoadSceneAsync(string lvl)
		{
			AsyncOperation async = SceneManager.LoadSceneAsync(lvl);
			StartCoroutine(LoadSceneAsync(async));
		}
		private IEnumerator LoadSceneAsync(AsyncOperation async)
		{
            
            controller.OnStartLoadScene.Invoke(controller);
			//ProgressBarEnabled();
			async.allowSceneActivation = false;
			while (!async.isDone)
			{
				//ProgressBarSetValue(async.progress + 0.1f);
				var progress = async.progress * 100f;
                controller.OnProgressLoadScene.Invoke(controller, progress);
				if (async.progress < 0.9f && Mathf.RoundToInt(progress) != 100)
				{
					async.allowSceneActivation = false;
				}
				else
				{
					if (async.allowSceneActivation) yield return null ;
					async.allowSceneActivation = true;
                    
                    controller.OnEndLoadScene.Invoke(controller);
					//ProgressBarDisable();
				}
				yield return null;
			}
		}
#endregion
    }
}

