using Blocks;
using UnityEngine;
using Utility;

public class MagnetAreaDrawer : MonoBehaviour
{
	[SerializeField] private MagnetArea magnetArea;

	private void OnDrawGizmos()
	{
		if (magnetArea == null || magnetArea.Context == null)
		{
			return;
		}

		ObjectPool<Block> blocks = magnetArea.Context.PoolsContainer.Blocks;
		if (blocks == null)
		{
			return;
		}

		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, magnetArea.Radius);

		Gizmos.color = Color.blue;
		foreach (Block block in blocks.Active)
		{

			Vector2 pullDirection = transform.position - block.transform.position;
			float distance = pullDirection.magnitude;

			Gizmos.DrawRay(transform.position, -pullDirection.normalized * distance);
		}
	}
}
