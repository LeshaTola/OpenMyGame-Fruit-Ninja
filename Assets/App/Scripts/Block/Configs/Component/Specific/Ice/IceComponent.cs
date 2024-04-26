using Assets.App.Scripts.General;
using Blocks.Configs.Component.Specific;
using UnityEngine;

namespace Blocks.Configs.Component
{
	[CreateAssetMenu(fileName = "IceComponent", menuName = "Configs/Blocks/Components/Specific/Ice/IceComponent")]
	public class IceComponent : BasicComponent, IBonusComponent
	{
		[SerializeField, Min(0)] private int bonusTimer;
		[SerializeField, Range(0, 1)] private float timeScale;

		public bool IsValid { get; private set; }

		private float timer;
		private float currentTimeScale;

		public override void Execute(Block block)
		{
			if (Context.BonusController.IsContains(this))
			{
				timer = bonusTimer;
				return;
			}

			Context.BonusController.AddBonus(this);
		}

		public void StartBonus()
		{
			IsValid = true;
			timer = bonusTimer;
			Context.UiContext.IceEffectUI.Show();

			currentTimeScale = Time.timeScale;
			Time.timeScale = timeScale;
		}

		public void UpdateBonus()
		{
			if (timer <= 0)
			{
				IsValid = false;
			}

			timer -= Time.deltaTime;
		}

		public void StopBonus()
		{
			Time.timeScale = currentTimeScale;
			Context.UiContext.IceEffectUI.Hide();
		}
	}
}
