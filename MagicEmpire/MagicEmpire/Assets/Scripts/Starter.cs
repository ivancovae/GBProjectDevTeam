using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games.Controller;

namespace Games
{
    public class Starter : MonoBehaviour
    {
        public List<ControllerBase> controllers = new List<ControllerBase>();

		void Awake()
		{
			foreach (var controllerBase in controllers)
			{
				Toolbox.Add(controllerBase);
			}
		}
    }
}