using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Helpers;
using Games.Controller;
using Games.Interface;

namespace Games
{
public sealed class Toolbox : Singleton<Toolbox> 
	{
		private Dictionary<Type,object> data = new Dictionary<Type, object>();

		protected override void Awake()
		{
			base.Awake();
		}

		public static void Add(object obj)
		{
			var add = obj;
			var controller = obj as ControllerBase;
			
			if (controller != null)
				add = Instantiate(controller);
			else return;
			
			Instance.data.Add(obj.GetType(), add);

			if (add is IAwake)
			{
				(add as IAwake).OnAwake();
			}	
		}

		private static void Remove(object obj)
		{
			var controller = obj as ControllerBase;
			if (controller != null) 
			{
				if (controller is IDestroy)
				{
					(controller as IDestroy).OnDestroy();
				}
				Destroy(controller);
			}
			else return;
		}
		
		public static T Get<T>()
		{
			object resolve;
			Instance.data.TryGetValue(typeof(T), out resolve);
			return (T) resolve;
		}

		public void ClearScene()
		{
			// foreach(var controller in data.Values)
			// {
			// 	Remove(controller);
			// }
			data.Clear();
		}
	}
}