using UnityEngine;

namespace Games.Managers 
{
	// Менеджер создания новых объектов
	[CreateAssetMenu(fileName = "ManagerEvents",menuName = "Managers/ManagerEvents")]
	public class ManagerEvents : ManagerBase
	{
		// ссылка на создаваемый объект объект
		public GameObject prefab;
	
		// создание объекта по позиции
		public void CreatePrefab(Vector3 pos)
		{
			Instantiate(prefab, pos, Quaternion.identity);
		}
	}
}
