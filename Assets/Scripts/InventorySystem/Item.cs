using UnityEngine;
using System;
using UnityEngine.UI;

namespace Inventory
{


	[Serializable]
	public class Item
	{
		#region Properties
		[field: SerializeField] public string Name { get; set; }
		[field: SerializeField] public Sprite Icon { get; set; }
		#endregion

	}
}
