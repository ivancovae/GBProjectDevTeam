using UnityEngine;
using UnityEngine.UI;

namespace Games.Interface
{
	public interface IControl
	{
		GameObject Instance { get; }
		Selectable Control { get; }
	}

	public interface IControlText : IControl
	{
		Text GetText { get; } 
	}

	public interface IControlImage: IControl
	{
		Image GetImage { get; }
	}
}
