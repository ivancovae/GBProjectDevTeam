using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Interface;

namespace Games.Controller
{
    [CreateAssetMenu(fileName = "ControllerShop", menuName = "Controllers/ControllerShop")]
	public class ControllerShop : ControllerBase, IAwake 
	{
        private Shop _shop;

		public void RegisterBookCase(BookCase bookCase)
		{
			
		}

		public void OnAwake()
		{
			GameObject.Find("[SETUP]").AddComponent<ShopControllerComponent>().Setup(this);	
            _shop = GameObject.Find("[WORLD]/shop").GetComponent<Shop>();
		}
	}
}