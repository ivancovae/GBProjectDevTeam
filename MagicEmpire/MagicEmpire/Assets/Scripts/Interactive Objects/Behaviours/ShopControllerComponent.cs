using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Controller
{
    public class ShopControllerComponent : BaseControllerComponent
    {
        private ControllerShop controller;
        
        public void Setup(ControllerShop controller)
        {
            this.controller = controller;
        }

        public void RegisterCase(BookCase bookCase)
        {
            
        }
    }
}