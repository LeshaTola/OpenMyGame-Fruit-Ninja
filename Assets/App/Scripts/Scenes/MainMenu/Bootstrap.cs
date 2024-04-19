using General;
using System.Collections.Generic;
using TNRD;
using UnityEngine;

namespace MainMenu
{

	public class Bootstrap : MonoBehaviour
	{
		[SerializeField] private List<SerializableInterface<IInitable>> initableObjects;

		private void Awake()
		{
			foreach (var initable in initableObjects)
			{
				initable.Value.Init();
			}
		}
	}
}
