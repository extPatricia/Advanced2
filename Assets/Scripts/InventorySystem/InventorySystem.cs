using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Inventory
{


	public class InventorySystem : Singleton<InventorySystem>
	{
		#region Properties
		public List<Item> Items => _items;
		public Item SelectedItem { get; private set; }
		#endregion

		#region Fields
		[Header("Object Definition")]
		[SerializeField] private Weapon[] _weapons;
		[SerializeField] private Food[] _food;
		[SerializeField] private Other[] _other;

		[Header("Item Pool")]
		[SerializeField] private List<Item> _items = new List<Item>();

		#endregion

		#region Unity Callbacks
		// Start is called before the first frame update
		void Awake()
		{			
			InitializeItems();
		}
		#endregion

		#region Public Methods
		public void AddItem(Item item)
		{
			_items.Add(item);
			InventoryEventSystem.Instance.ItemAdded(item);
		}

		public void SelectItem(Item currentItem)
		{
			SelectedItem = currentItem;
			InventoryEventSystem.Instance.ItemSelected(SelectedItem);
		}

		public void SellCurrentItem()
		{
			if (SelectedItem is ISellable sellableItem)
			{
				float money = sellableItem.Sell();
				
				InventoryEventSystem.Instance.MoneyGained(money);
				InventoryEventSystem.Instance.ItemSold(SelectedItem);

				ConsumeItem(SelectedItem);
			}
		}

		public void UseCurrentItem()
		{
			if (SelectedItem is IUsable usable)
			{
				usable.Use();
				InventoryEventSystem.Instance.ItemUsed(SelectedItem);

				if (SelectedItem is IConsumable)
					ConsumeItem(SelectedItem);
			}
		}

		public void ConsumeItem(Item item)
		{
			InventoryEventSystem.Instance.ItemConsumed(item);
			SelectedItem = null;
		}
		#endregion

		#region Private Methods
		private void InitializeItems()
		{
			_items.AddRange(_weapons);
			_items.AddRange(_food);
			_items.AddRange(_other);
		}
		#endregion

	}

}