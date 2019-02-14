using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Games;

namespace Games.Controller
{
    public sealed class InventoryController : BaseController
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public BookCase SpawnBookCase(string name, Vector3 pos)
        {
            return Main.Instance.ObjectManager.Inventory.SpawnBookCase(name, pos);
        }

        public void DespawnBookCase(BookCase bc)
        {
            Main.Instance.ObjectManager.Inventory.DespawnBookCase(bc);
        }
    }
}