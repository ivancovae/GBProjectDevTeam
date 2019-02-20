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

        private IEnumerable<DataBookCase> FindCase(string name)
        {
            return _inventary.Where(o => o.Name==name);
        }
                
        // Взять предмет из Инвентаря 
        public void SetReservedCase(string name)
        {
            var obj = FindCase(name);
            if (obj.Count() > 0) 
            {
                var data = obj.First();
                _reservedCase = GameObject.Instantiate(data.PrefabBookCase, ControllerInput.mousePosition, Quaternion.identity, _dynamic);
                _reservedCase.Name = name;
                // ToDo: Помечать предмет, как используемый
                data.Hidden = true;
            }
        }

        // Вернуть предмет в Инвентарь
        public void ReturnReservedCase()
        {
            if (_reservedCase)
            {
                var obj = FindCase(_reservedCase.Name);
                if (obj.Count() > 0) 
                {
                    var data = obj.First();
                    GameObject.Destroy(_reservedCase.InstanceObject);
                    _reservedCase = null;
                    // ToDo: Помечать предмет, как используемый
                    data.Hidden = false;
                }
            }
        }
        
        // Передать в магазин
        public BookCase PlaceReservedCase()
        {
            if (_reservedCase)
            {
                var obj = _reservedCase;
                _reservedCase = null;
                return obj;
            }
            return null;
        }
        
		public void OnAwake()
		{
			GameObject.Find("[SETUP]").AddComponent<InventoryControllerComponent>().Setup(this);

            _inventary.AddRange(Resources.LoadAll<DataBookCase>("bookcases"));
            _dynamic = GameObject.Find("[WORLD]/Dynamic").transform;
		}
	}
}
