using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Games.Controller;

namespace Games
{
    // Поведение карты магазинов
    public class ShopsMap : BaseObjectScene
    {
        [SerializeField] private List<ShopOnMap> _shops = new List<ShopOnMap>();

        protected override void Awake()
        {
            base.Awake();

            var findShops = GameObject.FindObjectsOfType<ShopOnMap>();
            foreach (var shop in findShops)
            {
                _shops.Add(shop);
            }
        }
    }
}
