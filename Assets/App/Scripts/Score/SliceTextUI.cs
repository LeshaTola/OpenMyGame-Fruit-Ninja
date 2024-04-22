using DG.Tweening;
using General;
using System;
using TMPro;
using UnityEngine;

namespace Score
{
	public class SliceTextUI : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI text;

		[Header("Animation")]
		[SerializeField] private float scaleTime = 1.0f;
		[SerializeField] private MinMaxValue<Vector2> scale;
		[SerializeField] private float verticalOffset;
		[SerializeField] private float moveTime;

		private Action releaseAction;

		public void Init(Action releaseAction)
		{
			this.releaseAction = releaseAction;

			Hide();
		}

		public void SetText(string text)
		{
			this.text.text = text;
		}

		public void Show()
		{
			gameObject.SetActive(true);
			var sequence = DOTween.Sequence();
			sequence.Append(transform.DOScale(scale.Max, scaleTime));
			sequence.Append(transform.DOMoveY(transform.position.y + verticalOffset, moveTime));
			sequence.onComplete += Hide;

		}

		private void Hide()
		{
			transform.DOScale(scale.Min, scaleTime).onComplete += () =>
			{
				gameObject.SetActive(false);
				releaseAction();
			};
		}

	}
}
