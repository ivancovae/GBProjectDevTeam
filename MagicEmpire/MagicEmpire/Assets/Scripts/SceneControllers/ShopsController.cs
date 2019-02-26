using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Controller
{
    public class ShopsController : BaseController
    {
        [SerializeField] private ShopsMap _shops;
        [SerializeField] private ShopOnMap _selectedShop;

        private void Awake()
        {
            GameObject go = GameObject.Find("[SCENE]/shops");
            if (go)
                _shops = go.GetComponent<ShopsMap>();
        }
        
        public void Start()
        {

        }

        public void Update()
        {
            if (!Enabled) return;


        }

        public override void On()
        {
            if (Enabled) return;
            base.On();


        }

        public override void Off()
        {
            if (!Enabled) return;
            base.Off();

            
        }

        public override void Switch()
        {
            base.Switch();

            
        }

        public void SelectShop(ShopOnMap shop)
        {
            if (shop != null)
            {
                _selectedShop = shop;
                _selectedShop.SelectShop();
            }
        }

        public void DeselectShop()
        {
            if (_selectedShop != null)
            {
                _selectedShop.DeselectShop();
                _selectedShop = null;
            }
        }
    }
}
