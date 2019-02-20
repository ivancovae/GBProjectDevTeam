using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games;
using Games.Helpers;

namespace Games.Controller
{
    public sealed class InputControllerComponent : BaseControllerComponent
    {
        private ControllerInput controller;

        public void Setup(ControllerInput controller)
        {
            this.controller = controller;
        }
        
        private void Update ()
        {   
            ControllerInput.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);         
            var controllerInventory = Toolbox.Get<ControllerInventory>();
            
            if (Input.GetMouseButtonDown(MouseButton.LeftButton.GetValue()))
            {
                ControllerInput.IsClicked = true;
                controller.OnMouseButtonDown.Invoke(controller);
                //controllerInventory.SpawnBookCase("bookcase0", controller.mousePosition);
                //isReady = false;
            }

            if (Input.GetMouseButtonUp(MouseButton.LeftButton.GetValue()))
            {
                ControllerInput.IsClicked = false;
                controller.OnMouseButtonUp.Invoke(controller);
                // if (isReady)
                //     controllerInventory.TransferBookCase();
                // else
                //     controllerInventory.DespawnBookCase();
            }

            // if (controller.IsClicked && controllerInventory.ReservedCase)
            // {
            //     controller.mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //     var collider = Physics2D.OverlapPoint(new Vector2(controller.mousePosition.x, controller.mousePosition.y));
            //     if (collider)
            //     {
            //         var go = collider.gameObject;
            //         var cellStory = go.GetComponent<CellStore>();
            //         if (cellStory)
            //         {
            //             var pos = cellStory.Position;
            //             controllerInventory.ReservedCase.Position = new Vector2(pos.x, pos.y);
            //             isReady = true;
            //         }
            //     } 
            //     else
            //     {
            //         controllerInventory.ReservedCase.Position = Vector2.Lerp(transform.position, controller.mousePosition, controllerInventory.Speed);
            //         isReady = false;
            //     }
            // }
        }
    }
}