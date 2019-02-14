using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Controller
{
    public class ShopController : BaseController
    {
        private Shop _shop;

        protected override void Awake()
        {
            base.Awake();
            _shop = GameObject.Find("[WORLD]/shop").GetComponent<Shop>();
        }
    }
}