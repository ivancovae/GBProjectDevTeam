using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        
        private bool _isActiveSelect = false;
        [SerializeField]private BookCase obj;
        private float speed = 10f;
        
        public void Update ()
        {
            if (Input.GetMouseButtonDown(MouseButton.LeftButton.GetValue()))
            {
                _isActiveSelect = true;
                var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
                obj = Toolbox.Get<ControllerInventory>().SpawnBookCase("bookcase0", position);
            }

            if (Input.GetMouseButtonUp(MouseButton.LeftButton.GetValue()))
            {
                _isActiveSelect = false;
                Toolbox.Get<ControllerInventory>().DespawnBookCase(obj);
                obj = null;
            }

            if (_isActiveSelect)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                obj.transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed); 
            }
        }
    }
}