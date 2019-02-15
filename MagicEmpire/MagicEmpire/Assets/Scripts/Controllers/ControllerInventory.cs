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
        
        // взятие предмета из инвентаря
        public BookCase SpawnBookCase(string nameBookcase, Vector3 pos) 
        {
            var obj = _inventary.Where(o => o.Name==nameBookcase);
            if (obj.Count() > 0) 
            {
                var data = obj.First();
                var newObj = GameObject.Instantiate(data.PrefabBookCase, pos, Quaternion.identity, _dynamic);
                newObj.Name = nameBookcase;
                 
                return newObj;
            }
            return null;
        }   

        // возврат предмета в инвентарь
        public void DespawnBookCase(BookCase bc) 
        {
            var obj = _inventary.Where(o => o.Name==bc.Name);
            if (obj.Count() > 0) 
            {
                GameObject.Destroy(bc.InstanceObject);
            }
        }
        
		public void OnAwake()
		{
			GameObject.Find("[SETUP]").AddComponent<InventoryControllerComponent>().Setup(this);	
            _inventary.AddRange(Resources.LoadAll<DataBookCase>("bookcases"));
            _dynamic = GameObject.Find("[WORLD]/Dynamic").transform;
		}
	}
}
