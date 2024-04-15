using UnityEngine;

namespace Physics
{

	public class MyCollider : MonoBehaviour
	{
		[SerializeField] private float radius;

		public float Radius { get => radius * transform.localScale.x; set => radius = value; }

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(transform.position, Radius);
		}
	}
}
