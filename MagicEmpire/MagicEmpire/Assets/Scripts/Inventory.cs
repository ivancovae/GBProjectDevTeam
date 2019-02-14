using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Games
{
    [System.Serializable]
    public class Inventory
    {
        [SerializeField] private List<DataBookCase> _inventary = new List<DataBookCase>();
        
        public Inventory()
        {
            _inventary.AddRange(Resources.LoadAll<DataBookCase>("bookcases"));
        }

        public BookCase SpawnBookCase(string nameBookcase, Vector3 pos) 
        {
            var obj = _inventary.Where(o => o.Name==nameBookcase);
            if (obj.Count() > 0) 
            {
                var data = obj.First();
                var newObj = GameObject.Instantiate(data.PrefabBookCase, pos, Quaternion.identity);
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
                GameObject.Destroy(bc.InstanceObject);
            }
        }
    }
}