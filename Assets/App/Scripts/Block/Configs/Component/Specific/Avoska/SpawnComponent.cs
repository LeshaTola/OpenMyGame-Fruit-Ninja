using General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "SpawnComponent", menuName = "Configs/Blocks/Components/Specific/Avoska/SpawnComponent")]
	public class SpawnComponent : BasicComponent
	{
		[SerializeField] private List<Config> toSpawn;
		[SerializeField] private MinMaxValue<int> countRange;
		[SerializeField] private float pushForce;
		[SerializeField] private float invulnerabilityTime;

		public override void Execute(Block block)
		{
			int count = Random.Range(countRange.Min, countRange.Max);
			for (int i = 0; i < count; i++)
			{
				var newBlock = Context.PoolsContainer.Blocks.Get();

				newBlock.transform.position = block.transform.position;

				Config blockConfig = toSpawn[Random.Range(0, toSpawn.Count)];
				newBlock.ResetBlock();
				newBlock.Init(blockConfig, Context);

				PushBlock(newBlock);
				TurnOnInvulnerability(newBlock);
			}
		}

		private void TurnOnInvulnerability(Block newBlock)
		{
			newBlock.Collider.Radius = 0;
			newBlock.StartCoroutine(StopInvulnerability(newBlock));
		}

		private void PushBlock(Block newBlock)
		{
			Vector2 pushVector = new Vector2(Random.Range(-1f, 1f), 1f);
			newBlock.Movement.Push(pushVector.normalized * pushForce);
		}

		private IEnumerator StopInvulnerability(Block block)
		{
			yield return new WaitForSeconds(invulnerabilityTime);
			block.Collider.Radius = block.Config.Radius;
		}
	}
}

