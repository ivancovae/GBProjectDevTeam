using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Interface;
using Games.Helpers;

namespace Games.Managers 
{
	public class ManagerTimer : ManagerBase
	{
		public List<IEvent> poolTimers = new List<IEvent>();

		public void Add(float finishTime, Action callBack)
		{
			var freeTimer = poolTimers.Find(t => t.IsRunning == false) as Timer;
			if (freeTimer == null)
			{
				var timer = new Timer(callBack, finishTime);
				poolTimers.Add(timer);
				timer.Restart();
				return;
			}
			freeTimer.Restart(callBack,finishTime);
		}
		
	}
}