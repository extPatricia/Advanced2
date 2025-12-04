using UnityEngine;
using System;

namespace Inventory
{
	[Serializable]
	public class Other : Item, ISellable
	{
		[field: SerializeField] public float Price { get; set; }
		public event Action<float> OnGetMoney;

		public float Sell()
		{
			Debug.Log("You win " + Price);
			OnGetMoney?.Invoke(Price);
			return Price;
		}

	}

}