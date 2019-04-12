using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Games.UI
{
    public class ShopMenu : BaseMenu
    {            
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private ButtonUI _back;

#region Button for select Cases TODO: Delete
        [SerializeField] private ButtonUI _case0;
        [SerializeField] private ButtonUI _case1;
#endregion

        private void Start()
        {
            _back.GetText.text = "Back";
            _back.GetControl.onClick.AddListener(delegate
            {
                Back();
            });

            _case0.GetText.text = "Case 0";
            _case0.GetControl.onClick.AddListener(delegate
            {
                Main.Instance.PositioningController.ReservedItem(0);
            });

            _case1.GetText.text = "Case 1";
            _case1.GetControl.onClick.AddListener(delegate
            {
                
            });
        }
        private void Update()
        {

        }
        private void Back()
        {
            LoadScene(Main.Instance.Scenes.GlobalMapScene.SceneName);
        }
        public override void Hide()
        {
            if (!IsShow) return;
            IsShow = false;
        }
        public override void Show()
        {
            if (IsShow) return;
            IsShow = true;
        }

        private void LoadScene(string lvl)
		{
			SceneManager.sceneLoaded += delegate 
			{
				Main.Instance.InitGlobalMap();
			};
			Interface.LoadSceneAsync(lvl);
		}
    }
}