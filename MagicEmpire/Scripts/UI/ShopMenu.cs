using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Games.UI
{
    public class ShopMenu : BaseMenu
    {            
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private ButtonUI _back;
        
        private void Start()
        {
            _back.GetText.text = "Back";
            _back.GetControl.onClick.AddListener(delegate
            {
                Back();
            });
        }
        private void Update()
        {

        }
        private void Back()
        {
            Interface.UndoExecute();
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
    }
}