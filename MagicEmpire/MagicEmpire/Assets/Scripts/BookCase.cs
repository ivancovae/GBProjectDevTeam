using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Controller;

namespace Games
{
    public class BookCase : BaseObjectScene
    {
        private CellStore _cs;
        void OnTriggerEnter2D(Collider2D collision)
        {
            //_cs = collision.gameObject.GetComponent<CellStore>();
            //if (_cs)
            //{
                //var controllerInventory = Toolbox.Get<ControllerInventory>();
                //var bookCase = controllerInventory.TransferBookCase();
                //if (bookCase)
                //    bookCase.Position = _cs.gameObject.transform.position;
            //}
        }
        void OnTriggerStay2D(Collider2D collision)
        {

        }
        void OnTriggerExit2D(Collider2D collision)
        {
            _cs = null;
        }
    }
}