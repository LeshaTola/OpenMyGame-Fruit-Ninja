using DG.Tweening;
using Health;
using UnityEngine;

namespace Blocks.Configs.Component
{
	public class BonusHealthComponent : BasicComponent
	{
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

			Context.HealthController.AddHealth(health);

			HealthBarUI healthBar = Context.UiContext.HealthBarUI;
			HealthIconUI healthIcon = healthBar.GetHeartIcon(Context.HealthController.CurrentHealth - 1);
			Vector2 healthPosition = healthIcon.transform.position;
			healthIcon.transform.position = block.transform.position;

			Sequence sequence = DOTween.Sequence();
			var tween = healthIcon.transform
				.DOMove(healthPosition, moveTime)
				.SetEase(Ease.OutCirc);
			sequence.Append(tween);
		}
	}
}
