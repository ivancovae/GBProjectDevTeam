using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Games;

namespace Games.Controller
{
    public sealed class InventoryControllerComponent : BaseControllerComponent
    {
        private ControllerInventory controller;

        public void Setup(ControllerInventory controller)
        {
            this.controller = controller;
        }

        public void SpawnBookCase(string name, Vector3 pos)
        {
            controller.SpawnBookCase(name, pos);
        }

        public void DespawnBookCase()
        {
            controller.DespawnBookCase();
        }

        public BookCase TransferBookCase()
        {
            return controller.TransferBookCase();
        }
    }
}