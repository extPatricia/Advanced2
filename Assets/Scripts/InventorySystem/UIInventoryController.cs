using Inventory;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[Header("UI References")]
	[SerializeField] private ItemButton _prefabItemButton;
	[SerializeField] private Transform _inventoryPanel;
	[SerializeField] private Transform _itemPoolPanel;
	[SerializeField] private Button _useButton;
	[SerializeField] private Button _sellButton;

	[Header("Item Selected")]
	[SerializeField] private ItemButton _selectedButtonItem;

	[Header("Inventory System Reference")]
	[SerializeField] private InventorySystem _inventorySystem;
	#endregion

	#region Unity 
	private void Awake()
	{
		_inventorySystem = InventorySystem.Instance;
	}
	// Start is called before the first frame update
	void Start()
    {
		InitializeUI();

		InventoryEventSystem.Instance.OnItemConsumed += OnItemConsumed;
		InventoryEventSystem.Instance.OnItemSold += OnItemSold;
		InventoryEventSystem.Instance.OnItemUse += OnItemUsed;
		InventoryEventSystem.Instance.OnItemAdded += OnItemAdded;
		InventoryEventSystem.Instance.OnItemSelected += OnItemSelected;

		_useButton.onClick.AddListener(_inventorySystem.UseCurrentItem);
		_sellButton.onClick.AddListener(_inventorySystem.SellCurrentItem);
	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	private void InitializeUI()
	{
		foreach (var item in _inventorySystem.Items)
		{
			CreateItemButtonInPool(item);
		}
		_prefabItemButton.gameObject.SetActive(false);
	}

	private void CreateItemButtonInPool(Item item)
	{
		ItemButton itemButton = Instantiate(_prefabItemButton, _itemPoolPanel);
		itemButton.gameObject.SetActive(true);
		itemButton.CurrentItem = item;
		itemButton.OnClick += OnItemPoolClick;//() => AddToInventory(itemButton);	
	}

	private void OnItemPoolClick(ItemButton itemButton)
	{
		AddToInventory(itemButton);
	}

	private void AddToInventory(ItemButton itemButton)
	{
		ItemButton inventaryButton = Instantiate(_prefabItemButton, _inventoryPanel);
		inventaryButton.gameObject.SetActive(true);
		inventaryButton.CurrentItem = itemButton.CurrentItem;
		inventaryButton.OnClick += OnInventorySelectItem; //() => _inventorySystem.SelectItem(inventaryButton.CurrentItem);

		Destroy(itemButton.gameObject);
	}

	private void OnInventorySelectItem(ItemButton button)
	{
		_inventorySystem.SelectItem(button.CurrentItem);
	}

	private void OnItemSelected(Item item)
	{
		_useButton.gameObject.SetActive(item is IUsable);
		_sellButton.gameObject.SetActive(item is ISellable);

		var itemButtons = _inventoryPanel.GetComponentsInChildren<ItemButton>();
		foreach (var itemButton in itemButtons)
		{
			if (itemButton.CurrentItem == item)
			{
				_selectedButtonItem = itemButton;
				break;
			}
		}

	}

	private void OnItemAdded(Item item)
	{
		Debug.Log($"Add {item.Name} item...");
	}
	private void OnItemUsed(Item item)
	{
		Debug.Log($"Use {item.Name} item...");
	}

	private void OnItemSold(Item item)
	{
		Debug.Log($"Sell {item.Name} item...");
	}

	private void OnItemConsumed(Item item)
	{
		if (_selectedButtonItem != null && _selectedButtonItem.CurrentItem == item)
		{
			Destroy(_selectedButtonItem.gameObject);
			_selectedButtonItem = null;
		}
		
		_sellButton.gameObject.SetActive(false);
		_useButton.gameObject.SetActive(false);

	}

	private void OnDisable()
	{
		if (InventoryEventSystem.Instance == null)
			return;

		InventoryEventSystem.Instance.OnItemConsumed -= OnItemConsumed;
		InventoryEventSystem.Instance.OnItemSold -= OnItemSold;
		InventoryEventSystem.Instance.OnItemUse -= OnItemUsed;
		InventoryEventSystem.Instance.OnItemAdded -= OnItemAdded;
		InventoryEventSystem.Instance.OnItemSelected -= OnItemSelected;
	}
	#endregion

}
