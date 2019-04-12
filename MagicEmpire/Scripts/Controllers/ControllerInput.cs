using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Games.Interface;

namespace Games.Controller
{
	[System.Serializable] public class UnityEventController<T>:UnityEvent<T> where T : ControllerBase {}

	[CreateAssetMenu(fileName = "ControllerInput", menuName = "Controllers/ControllerInput")]
	public class ControllerInput : ControllerBase, IAwake 
	{
		public static bool IsClicked { get; set; }
		public static Vector3 mousePosition { get; set; }

		public UnityEventController<ControllerInput> OnMouseButtonDown;
		public UnityEventController<ControllerInput> OnMouseButtonUp;
		
		public void OnAwake()
		{
			GameObject.Find("[SETUP]").AddComponent<InputControllerComponent>().Setup(this);	
        	OnMouseButtonDown = new UnityEventController<ControllerInput>();
			OnMouseButtonUp = new UnityEventController<ControllerInput>();
		}
	}
}
