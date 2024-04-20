using Blocks;
using General;
using Score;
using UnityEngine;

namespace Slicing.Combo
{
	public class ComboController : MonoBehaviour
	{
		[SerializeField] private MinMaxValue<int> comboConstrains;
		[SerializeField] private ScoreController scoreController;
		[SerializeField] private float delayComboDestroy;
		[SerializeField] private ComboUI ComboTemplate;
		[SerializeField] private Camera mainCamera;


		private int combo;
		private int score;
		private int fruits;
		private float delay;
		private Block lastBlock;
		private Vector2 lastBlockPosition;

		private void Update()
		{
			delay -= Time.deltaTime;

			if (combo >= comboConstrains.Min)
			{
				if (delay <= 0)
				{
					ApplyCombo();
				}
			}

			if (delay <= 0)
			{
				ResetCombo();
			}
		}

		public void AddCombo(Block block, int score, int additionalCombo = 1)
		{
			if (combo < comboConstrains.Max)
			{
				combo += additionalCombo;
			}
			this.score += score;

			lastBlock = block;
			lastBlockPosition = block.transform.position;

			fruits++;
			delay = delayComboDestroy;
		}

		private void ApplyCombo()
		{
			int additionalScore = score * (combo - 1);
			scoreController.AddScore(additionalScore);

			var comboUI = Instantiate(ComboTemplate, transform);
			comboUI.Init(mainCamera);
			comboUI.Move(lastBlockPosition);
			comboUI.UpdateUI(fruits, combo);
			comboUI.Show();

			ResetCombo();
		}

		private void ResetCombo()
		{
			combo = 0;
			score = 0;
			fruits = 0;
			delay = delayComboDestroy;
			lastBlock = null;
		}
	}
}