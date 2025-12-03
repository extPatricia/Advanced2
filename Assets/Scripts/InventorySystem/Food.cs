using UnityEngine;
using System;

namespace Inventory
{
	public interface IConsumable { }

	[Serializable]
	public class Food : Item, IUsable, ISellable, IConsumable
	{
		[field: SerializeField] public float HelthRestore { get; set; }
		[field: SerializeField] public float Price { get; set; }

		public float Sell()
		{
			Debug.Log("You win " + Price);
			return Price;
		}

		public void Use()
		{
			Debug.Log("You eat " + Name + " and you restore " + HelthRestore + " health");
		}

	}

}