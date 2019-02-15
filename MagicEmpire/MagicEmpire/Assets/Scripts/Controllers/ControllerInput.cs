using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Interface;

namespace Games.Controller
{

[CreateAssetMenu(fileName = "ControllerInput", menuName = "Controllers/ControllerInput")]
	public class ControllerInput : ControllerBase, IAwake 
	{
		public bool IsClicked { get; set; }
		public Vector3 mousePosition { get; set; }

		public void OnAwake()
		{
			GameObject.Find("[SETUP]").AddComponent<InputControllerComponent>().Setup(this);	
		}
	}
}
