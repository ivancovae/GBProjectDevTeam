using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Controller
{
    public class UpdateControllerComponent : MonoBehaviour
    {
        private ControllerUpdate controller;

            public void Setup(ControllerUpdate controller)
            {
                this.controller = controller;
            }

            private void Update()
            {
                controller.Tick();
            }

            private void FixedUpdate()
            {
                controller.TickFixed();
            }

            private void LateUpdate()
            {
                controller.TickLate();
            }
    }
}
