using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private ItemsShop _items;

        [SerializeField] private ShopItem _reservedItem;
        [SerializeField] private GameObject _testItem;
        
        
        public ShopItem GetItem(int num)
        {
            return _items.GetItem(num);
        }
    }
}