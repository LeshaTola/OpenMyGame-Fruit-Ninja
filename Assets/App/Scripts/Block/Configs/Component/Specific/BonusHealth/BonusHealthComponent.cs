using DG.Tweening;
using Health;
using UnityEngine;

namespace Blocks.Configs.Component
{
	public class BonusHealthComponent : BasicComponent
	{
		[SerializeField] private HealthGameObject healthGameObject;
		[SerializeField] private float moveTime;
		[SerializeField] private float scaleTime;
		[SerializeField] private int health;

		public override void Execute(Block block)
		{
			PlayHealthAnimation(block);
		}

		private void PlayHealthAnimation(Block block)
		{
			if (Context.HealthController.CurrentHealth == Context.HealthController.MaxHealth)
			{
				return;
			}

			var healthIcon = GameObject.Instantiate(healthGameObject, block.transform.position, Quaternion.identity);
			Sequence sequence = DOTween.Sequence();
			var tween = healthIcon.transform
				.DOMove(Context.UiContext.HealthBarUI.GetNextHeartPosition(), moveTime)
				.SetEase(Ease.OutCirc);
			sequence.Append(tween);

			sequence.onComplete += () =>
			{
				Context.HealthController.AddHealth(health);
				healthIcon.Hide();
			};
		}
	}
}
