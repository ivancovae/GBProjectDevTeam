using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Games
{
    public class Inventory : BaseObjectScene
    {
        [SerializeField] private List<DataBookCase> _inventary = new List<DataBookCase>();
        
        protected override void Awake()
        {
            base.Awake();
        }

        // Показать список полок на панели
        private void ShowCases()
        {

        }

        public BookCase SpawnBookCase(string nameBookcase, Vector3 pos) 
        {
            var obj = _inventary.Where(o => o.Name==nameBookcase);
            if (obj.Count() > 0) 
            {
                var data = obj.First();
                data.Used = true;
                var newObj = Instantiate(data.PrefabBookCase, pos, Quaternion.identity);
                newObj.Name = nameBookcase;
                return newObj;
            }
            return null;
        }   

        public void DespawnBookCase(BookCase bc) 
        {
            var obj = _inventary.Where(o => o.Name==bc.Name);
            if (obj.Count() > 0) 
            {
                obj.First().Used = false;
                Destroy(bc.InstanceObject);
            }
        }
    }
}