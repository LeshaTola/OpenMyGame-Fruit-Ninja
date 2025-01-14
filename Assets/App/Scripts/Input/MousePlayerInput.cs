﻿using System;
using UnityEngine;

namespace Input
{
	public class MousePlayerInput : IPlayerInput
	{
		public event Action<Vector3> OnStartInput;

		private Vector3 prevMousePosition;
		private Camera mainCamera;

		public MousePlayerInput(Camera mainCamera)
		{
			this.mainCamera = mainCamera;
		}

		public Delta GetInputDelta()
		{
			Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

			if (UnityEngine.Input.GetMouseButtonDown(0))
			{
				OnStartInput?.Invoke(worldMousePosition);

				prevMousePosition = worldMousePosition;
				Delta mouseDelta = new Delta()
				{
					currPos = worldMousePosition,
					prevPos = prevMousePosition
				};
				return mouseDelta;
			}

			if (UnityEngine.Input.GetMouseButton(0))
			{
				Delta mouseDelta = new Delta()
				{
					currPos = worldMousePosition,
					prevPos = prevMousePosition
				};
				prevMousePosition = worldMousePosition;
				return mouseDelta;

			}
			return default;
		}
	}
}
