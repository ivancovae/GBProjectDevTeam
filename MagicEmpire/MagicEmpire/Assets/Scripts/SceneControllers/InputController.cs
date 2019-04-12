using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Games.Interface;
using Games.Helpers;

namespace Games.Controller
{
	[System.Serializable] public class UnityEventController<T>:UnityEvent<T> where T : BaseController {}
	public class InputController : BaseController
	{
		public static bool IsClicked { get; set; }
		public static Vector3 mousePosition { get; set; }

		public UnityEventController<InputController> OnMouseButtonDown;
		public UnityEventController<InputController> OnMouseButtonUp;

		private void Awake()
		{
			OnMouseButtonDown = new UnityEventController<InputController>();
			OnMouseButtonUp = new UnityEventController<InputController>();
		}

		private void Update()
		{
			mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Input.GetMouseButtonDown(MouseButton.LeftButton.GetValue()))
            {
                IsClicked = true;
                OnMouseButtonDown.Invoke(this);
            }

            if (Input.GetMouseButtonUp(MouseButton.LeftButton.GetValue()))
            {
                IsClicked = false;
                OnMouseButtonUp.Invoke(this);
            }

		}
	}
}
