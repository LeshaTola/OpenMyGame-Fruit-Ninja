using UnityEngine;

namespace Slicing.SliceStrategy
{
	public interface ISliceStrategy
	{
		public void Slice(Vector2 delta);
	}
}
