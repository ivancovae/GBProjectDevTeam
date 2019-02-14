using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        public Inventory Inventory => _inventory;

        private void Awake()
        {
            _inventory = new Inventory();
        }
    }
}