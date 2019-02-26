using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Interface;

namespace Games.Controller
{

[CreateAssetMenu(fileName = "ControllerUpdate", menuName = "Controllers/ControllerUpdate")]
	public class ControllerUpdate : ControllerBase, IAwake 
	{
		// оптимизация в последующем, если потребуется можно задать размер листа при инсталяции
		private List<ITick> ticks = new List<ITick>(/* count */);
		private List<ITickFixed> ticksFixes = new List<ITickFixed>();
		private List<ITickLate> ticksLate = new List<ITickLate>();

		public static void AddTo(object updateble)
		{
			var mngUpdate = Toolbox.Get<ControllerUpdate>();
		
			if (updateble is ITick)
				mngUpdate.ticks.Add(updateble as ITick);
			
			if (updateble is ITickFixed)
				mngUpdate.ticksFixes.Add(updateble as ITickFixed);
			
			if (updateble is ITickLate)
				mngUpdate.ticksLate.Add(updateble as ITickLate);
		}
		public static void RemoveFrom(object updateble)
		{
			var mngUpdate = Toolbox.Get<ControllerUpdate>();
			if (updateble is ITick)
				mngUpdate.ticks.Remove(updateble as ITick);
			
			if (updateble is ITickFixed)
				mngUpdate.ticksFixes.Remove(updateble as ITickFixed);
			
			if (updateble is ITickLate)
				mngUpdate.ticksLate.Remove(updateble as ITickLate);
		}

		public void Tick()
		{
			for (var i = 0; i < ticks.Count; i++)
			{
				ticks[i].Tick();
			}
		}

		public void TickFixed()
		{
			for (var i = 0; i < ticksFixes.Count; i++)
			{
				ticksFixes[i].TickFixed();
			}
		}

		public void TickLate()
		{
			for (var i = 0; i < ticksLate.Count; i++)
			{
				ticksLate[i].TickLate();
			}
		}
		
		public void OnAwake()
		{
			GameObject.Find("[SETUP]").AddComponent<UpdateControllerComponent>().Setup(this);	
		}
	}
}