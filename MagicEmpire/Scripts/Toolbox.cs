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
			object possibleObj;
			if (Instance.data.TryGetValue(obj.GetType().GetHashCode(), out possibleObj))
			{
				InitializeObject(possibleObj);
			}	
			var add = obj;
			var scriptable = obj as ScriptableObject;
			if (scriptable) add = Instantiate(scriptable);
			InitializeObject(obj);

			Instance.data.Add(obj.GetType().GetHashCode(), add);
		}

		public static object Get(Type t)
		{
			object resolve;
			Instance.data.TryGetValue(t.GetHashCode(), out resolve);
			return resolve;
		}

		private static void Remove(object obj)
		{
			if (ApplicationIsQuitting)
			Instance.data.Remove(obj.GetType().GetHashCode());
		}

		public static void InitializeObject(object obj)
		{
			var awakeble = obj as IAwake;
			if (awakeble != null) awakeble.OnAwake();
			ProcessingUpdate.Default.Add(obj);
		}

		public static T GetCreate<T>()
		{
			object resolve;
			var    hasValue = Instance.data.TryGetValue(typeof(T).GetHashCode(), out resolve);

			if (!hasValue)
				Instance.data.TryGetValue(typeof(T).GetHashCode(), out resolve);
			return (T) resolve;
		}

		public static T Get<T>()
		{
			object resolve;

			var hasValue = Instance.data.TryGetValue(typeof(T).GetHashCode(), out resolve);

			if (!hasValue)
				Instance.data.TryGetValue(typeof(T).GetHashCode(), out resolve);
			return (T) resolve;
		}

		internal void ClearSessionData()
		{
			if (ApplicationIsQuitting) return;

			var toWipe = new List<int>();

			foreach (var pair in data)
			{
				var isKernel = pair.Value as IKernel;
				if (isKernel == null) toWipe.Add(pair.Key);

				var needToBeCleaned = pair.Value as IDisposable;
				if (needToBeCleaned == null) continue;

				needToBeCleaned.Dispose();
			}

			ProcessingScene.Default.Dispose();
			ProcessingUpdate.Default.Dispose();
			
			for (var i = 0; i < toWipe.Count; i++)
			{
				data.Remove(toWipe[i]);
			}
		}

		public static void DisposeObject(object obj)
		{
			if (isQuittingOrChangingScene()) return;

			var disposable = obj as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}
}