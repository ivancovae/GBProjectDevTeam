using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Games.UI
{
	public class GlobalMapMenu : BaseMenu
	{
		[SerializeField] private GameObject _mainPanel;
		[SerializeField] private ButtonUI _enterToShop;
		[SerializeField] private ButtonUI _buyProviders;
		[SerializeField] private ButtonUI _quit;

		private void Start()
		{
			_enterToShop.GetText.text = "Enter to shop";  // TODO: переделать для локализации
			_enterToShop.GetControl.onClick.AddListener(delegate
			{
				LoadScene(Main.Instance.Scenes.ShopScene.SceneName);
			});

			_buyProviders.GetText.text = "Buy providers"; // TODO: переделать для локализации
			_buyProviders.GetControl.onClick.AddListener(delegate
			{
				
			});

			_quit.GetText.text = "Quit"; // TODO: переделать для локализации
			_quit.GetControl.onClick.AddListener(delegate
			{
				Interface.QuitGame();
			});

		}

		private void Update()
		{

		}

		public override void Hide()
		{
			if (!IsShow) return;
			_mainPanel.gameObject.SetActive(false);
			IsShow = false;
		}

		public override void Show()
		{
			if (IsShow) return;
			_mainPanel.gameObject.SetActive(true);
			IsShow = true;
		}

		private void ShowOptions()
		{
			Interface.Execute(InterfaceObject.ShopMenu);
		}

		private void LoadScene(string lvl)
		{
			SceneManager.sceneLoaded += delegate 
			{
				Main.Instance.InitShop();
			};
			Interface.LoadSceneAsync(lvl);
		}
	}
}