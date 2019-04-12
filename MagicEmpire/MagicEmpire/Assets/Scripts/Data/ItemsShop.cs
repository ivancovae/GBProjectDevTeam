using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    [CreateAssetMenu(fileName = "ItemsShop", menuName = "Data/Items Shop")]
    public class ItemsShop : ScriptableObject
    {
        public string Name;
        [Multiline] public string Description;
        [SerializeField] private List<ShopItem> items = new List<ShopItem>();

        public ShopItem GetItem(int num)
        {
            return items[num];
        }
    }
}