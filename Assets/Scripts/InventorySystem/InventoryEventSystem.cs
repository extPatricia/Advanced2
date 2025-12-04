using UnityEngine;
using System;
using Inventory;

public class InventoryEventSystem : MonoBehaviour
{
	#region Properties
	public static InventoryEventSystem Instance;

	public event Action<float> OnMoneyGained;
	public event Action<Item> OnItemAdded;
	public event Action<Item> OnItemSold;
	public event Action<Item> OnItemUse;
	public event Action<Item> OnItemConsumed;
	public event Action<Item> OnItemSelected;

	#endregion

	#region Fields
	#endregion

	#region Unity Callbacks
	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			Instance = this;
		}
	}
	#endregion

	#region Public Methods
	public void MoneyGained(float money)
	{
		OnMoneyGained?.Invoke(money);
	}

	public void ItemAdded(Item item)
	{
		OnItemAdded?.Invoke(item);
	}

	public void ItemSold(Item item)
	{
		OnItemSold?.Invoke(item);
	}

	public void ItemUsed(Item item)
	{
		OnItemUse?.Invoke(item);
	}

	public void ItemConsumed(Item item)
	{
		OnItemConsumed?.Invoke(item);
	}

	public void ItemSelected(Item item)
	{
		OnItemSelected?.Invoke(item);
	}
	#endregion


}
