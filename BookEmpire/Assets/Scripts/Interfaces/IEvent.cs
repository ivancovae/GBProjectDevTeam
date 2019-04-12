using System;
namespace Games.Interface 
{
	public interface IEvent : IDisposable 
	{
		Type GetType { get; }
		bool IsRunning { get; }
		void Execute();
	}
}