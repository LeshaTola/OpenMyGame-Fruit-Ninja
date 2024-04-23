using DG.Tweening;
using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "BonusHealthComponent", menuName = "Configs/Blocks/Components/Specific/BonusHealth/BonusHealthComponent")]
	public class BonusHealthComponent : BasicComponent
	{
		[SerializeField] private GameObject healthGameObject;
		[SerializeField] private float moveTime;
		[SerializeField] private float scaleTime;
		[SerializeField] private int health;

		public override void Execute(Block block)
		{
			PlayHealthAnimation(block);
		}

		private void PlayHealthAnimation(Block block)
		{
			var healthIcon = Instantiate(healthGameObject, block.transform.position, Quaternion.identity);
			Sequence sequence = DOTween.Sequence();
			sequence.Append(healthIcon.transform
				.DOMove(Context.UiContext.HealthBarUI.GetNextHeartPosition(), moveTime)
				.SetEase(Ease.OutCirc));

			//sequence.Append(healthIcon.transform.DOScale(Vector3.zero, scaleTime));
			sequence.onComplete += () =>
			{
				Context.HealthController.AddHealth(health);
				Destroy(healthIcon.gameObject);
			};
		}
	}
}
