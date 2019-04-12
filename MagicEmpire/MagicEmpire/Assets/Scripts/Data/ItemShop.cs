using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Games
{
    [CreateAssetMenu(fileName = "Item", menuName = "Data/Item Shop")]
    public class ShopItem : ScriptableObject
    {
        public string Name;
        [Multiline] public string Description;
        
        public GameObject Prefab;
    }
}
