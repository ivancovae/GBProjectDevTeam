using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Helpers;

namespace Games.Controller
{
    public sealed class InputController : BaseController
    {
        private bool _isActiveSelect = false;
        [SerializeField]private BookCase obj;
        private float speed = 10f;
        
        public void Update ()
        {
            if (Input.GetMouseButtonDown(MouseButton.LeftButton.GetValue()))
            {
                _isActiveSelect = true;
                var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);    
                obj = Main.Instance.InventoryController.SpawnBookCase("bookcase0", position);
            }

            if (Input.GetMouseButtonUp(MouseButton.LeftButton.GetValue()))
            {
                _isActiveSelect = false;
                Main.Instance.InventoryController.DespawnBookCase(obj);
                obj = null;
            }

            if (_isActiveSelect)
            {
                obj.transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed); 
            }
        }
    }
}