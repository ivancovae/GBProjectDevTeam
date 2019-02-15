using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Games.Interface;

namespace Games.Controller
{

    [CreateAssetMenu(fileName = "ControllerInventory", menuName = "Controllers/ControllerInventory")]
	public class ControllerInventory : ControllerBase, IAwake 
	{
        [SerializeField] private List<DataBookCase> _inventary = new List<DataBookCase>();
        private Transform _dynamic;
        private BookCase _reservedCase;
        public BookCase ReservedCase => _reservedCase;

        public float Speed = 10f;
        
        // взятие предмета из инвентаря
        public void SpawnBookCase(string nameBookcase, Vector3 pos) 
        {
            var obj = _inventary.Where(o => o.Name==nameBookcase);
            if (obj.Count() > 0) 
            {
                var data = obj.First();
                _reservedCase = GameObject.Instantiate(data.PrefabBookCase, pos, Quaternion.identity, _dynamic);
                _reservedCase.Name = nameBookcase;
            }
        }   

        // возврат предмета в инвентарь
        public void DespawnBookCase() 
        {
            if (!_reservedCase)
                return;
            var obj = _inventary.Where(o => o.Name==_reservedCase.Name);
            if (obj.Count() > 0) 
            {
                if (_reservedCase)
                {
                    GameObject.Destroy(_reservedCase.InstanceObject);
                }
            }
        }

        public BookCase TransferBookCase()
        {
            var obj = _reservedCase;
            _reservedCase = null;
            return obj;
        }
        
		public void OnAwake()
		{
			GameObject.Find("[SETUP]").AddComponent<InventoryControllerComponent>().Setup(this);

            _inventary.AddRange(Resources.LoadAll<DataBookCase>("bookcases"));
            _dynamic = GameObject.Find("[WORLD]/Dynamic").transform;
		}
	}
}
