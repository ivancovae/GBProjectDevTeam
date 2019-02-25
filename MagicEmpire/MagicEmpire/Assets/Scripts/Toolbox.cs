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
		[SerializeField] private Dictionary<int, object> data = new Dictionary<int, object>(5, new FastComparable());

		public static bool Contains<T>() { return Instance.data.ContainsKey(typeof(T).GetHashCode()); }

		protected override void Awake()
		{
			base.Awake();
		}

		public static T Add<T>(Type type = null) where T : new()
		{
			object o;
			var hash = type == null ? typeof(T).GetHashCode() : type.GetHashCode();
			if (Instance.data.TryGetValue(hash, out o))
			{
				InitializeObject(o);
				return (T) o;
			}
			var created = new T();
			InitializeObject(created);
			Instance.data.Add(hash, created);

			return created;
		}

		public static void Add(object obj)
		{
			
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
		
		public static object Get(Type t)
		{
			object resolve;
			Instance.data.TryGetValue(t.GetHashCode(), out resolve);
			return resolve;
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