using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Controller
{
    public class PositioningController : BaseController
    {
        [SerializeField] private ManagerPositions _positions;
        [SerializeField] private GameObject _dynamic;

        [SerializeField] private ShopItem _reservedItem;
        [SerializeField] private GameObject _testItem;

        private void Awake()
        {
            GameObject go = GameObject.Find("[SCENE]/positions");
            if (go)
                _positions = go.GetComponent<ManagerPositions>();
            _dynamic = GameObject.Find("[SCENE]/Dynamic");
        }

        public void ReservedItem(int num)
        {
            _reservedItem = Main.Instance.ObjectManager.GetItem(num);
            _testItem = Instantiate(_reservedItem.Prefab, Vector3.zero, Quaternion.identity);
            _testItem.transform.parent = _dynamic.transform;
        }

        public void FreeItem()
        {
            _reservedItem = null;
            Destroy(_testItem);
        }
        
        public void Start()
        {
            
        }

        public void Update()
        {
            if (!Enabled) return;

            
        }

        public override void On()
        {
            if (Enabled) return;
            base.On();


        }

        public override void Off()
        {
            if (!Enabled) return;
            base.Off();

            
        }

        public override void Switch()
        {
            base.Switch();

            
        }
    }
}
