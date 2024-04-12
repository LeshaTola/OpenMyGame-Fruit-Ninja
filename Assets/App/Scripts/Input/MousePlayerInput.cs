using UnityEngine;

namespace Input
{
	public class MousePlayerInput : IPlayerInput
	{
		private Vector3 prevMousePosition;

		public Delta GetInputDelta()
		{
			Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);

			if (UnityEngine.Input.GetMouseButtonDown(0))
			{
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
