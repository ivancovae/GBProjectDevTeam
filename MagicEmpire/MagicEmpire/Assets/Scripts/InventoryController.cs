using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Games;

namespace Games.Controller
{
    public sealed class InventoryController : BaseController
    {
        [SerializeField] private Transform _inventoryGO;
        private Inventory _inventory;

        protected override void Awake()
        {
            base.Awake();
            _inventoryGO = GameObject.Find("[WORLD]/Inventory").transform;
            _inventory = _inventoryGO.GetComponent<Inventory>();
        }

        public BookCase SpawnBookCase(string name, Vector3 pos)
        {
            return _inventory.SpawnBookCase(name, pos);
        }

        public void DespawnBookCase(BookCase bc)
        {
            _inventory.DespawnBookCase(bc);
        }
    }
}