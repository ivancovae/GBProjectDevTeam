using System.Collections.Generic;
using UnityEngine;
using Games.Managers;
using Games.Helpers;

namespace Games
{
	public class Starter : MonoBehaviour 
	{
		public List<ManagerBase> managers = new List<ManagerBase>();

		void Awake()
		{
			foreach (var managerBase in managers)
			{
				Toolbox.Add(managerBase);
			}
		}
	}
}
