using Physics;
using UnityEngine;

namespace Blocks
{
	public class Half : MonoBehaviour
	{
		[SerializeField] private HalfVisual visual;
		[SerializeField] private Movement movement;

		public HalfVisual Visual { get => visual; set => visual = value; }
		public Movement Movement { get => movement; set => movement = value; }

		private void Update()
		{
			if (transform.position.y + transform.localScale.x / 2 < -Camera.main.orthographicSize)
			{
				Destroy(gameObject);
			}
		}
	}
}