using Inventory;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryEventSystem : Singleton<InventoryEventSystem>
{
	#region Properties
	public event Action<float> OnMoneyGained;
	public event Action<Item> OnItemAdded;
	public event Action<Item> OnItemSold;
	public event Action<Item> OnItemUse;
	public event Action<Item> OnItemConsumed;
	public event Action<Item> OnItemSelected;

	#endregion

	#region Fields
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
