using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Games.UI
{
	public class Interface : MonoBehaviour
	{
		public InterfaceResources InterfaceResources { get; private set; }
		private BaseMenu _currentMenu;
		private Stack<InterfaceObject> _interfaceObjects = new Stack<InterfaceObject>();

		#region Object
		private GlobalMapMenu _globalMapMenu;
		private ShopMenu _shopMenu;

		#endregion
		private void Start()
		{
			InterfaceResources = GetComponent<InterfaceResources>();
			_globalMapMenu = GetComponent<GlobalMapMenu>();
			_shopMenu = GetComponent<ShopMenu>();
			if (_globalMapMenu)
			{
				Execute(InterfaceObject.GlobalMapMenu);
			}
		}

		public void QuitGame()
		{
	#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
	#else
	Application.Quit ();
	#endif
		}

		public void Execute(InterfaceObject menuItem)
		{
			if (_currentMenu != null) _currentMenu.Hide();
			switch (menuItem)
			{
				case InterfaceObject.GlobalMapMenu:
					_currentMenu = _globalMapMenu;
					break;
				case InterfaceObject.ShopMenu:
					_currentMenu = _shopMenu;
					break;
				default:
					break;
			}

			if (_currentMenu != null)
			{
				_currentMenu.Show();
				_interfaceObjects.Push(menuItem);
			}
		}

		public void UndoExecute()
		{
			if (_currentMenu != null) _currentMenu.Hide();
			_interfaceObjects.Pop();
			InterfaceObject menuItem = _interfaceObjects.Peek();

			switch (menuItem)
			{
				case InterfaceObject.GlobalMapMenu:
					_currentMenu = _globalMapMenu;
					break;
				case InterfaceObject.ShopMenu:
					_currentMenu = _shopMenu;
					break;
				default:
					break;
			}

			if (_currentMenu != null)
			{
				_currentMenu.Show();
			}
		}

		#region ProgressBar
		public void ProgressBarSetValue(float value)
		{
			
		}
		public void ProgressBarEnabled()
		{
			ProgressBarSetValue(0);
		}
		public void ProgressBarDisable()
		{
			
		}
		#endregion

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
			ProgressBarEnabled();
			async.allowSceneActivation = false;
			while (!async.isDone)
			{
				ProgressBarSetValue(async.progress + 0.1f);
				float progress = async.progress * 100f;
				if (async.progress < 0.9f && Mathf.RoundToInt(progress) != 100)
				{
					async.allowSceneActivation = false;
				}
				else
				{
					if (async.allowSceneActivation) yield return null;
					async.allowSceneActivation = true;
					ProgressBarDisable();
				}
				yield return null;
			}
		}
		#endregion
	}
}