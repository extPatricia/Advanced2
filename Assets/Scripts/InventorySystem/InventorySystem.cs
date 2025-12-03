using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Inventory
{


	public class InventorySystem : MonoBehaviour
	{
		#region Properties
		#endregion

		#region Fields
		//TODO: Refacotr: move this to UIController
		[Header("UI References")]
		[SerializeField] private ItemButton _prefabItemButton;
		[SerializeField] private Transform _inventoryPanel;
		[SerializeField] private Button _useButton;
		[SerializeField] private Button _sellButton;

		[Header("Object Definition")]
		[SerializeField] private Weapon[] _weapons;
		[SerializeField] private Food[] _food;
		[SerializeField] private Other[] _other;
		[Header("Item Pool")]
		[SerializeField] private List<Item> _items = new List<Item>();
		[Header("Item Selected")]
		[SerializeField] private ItemButton _selectedItem;

		#endregion

		#region Unity Callbacks
		// Start is called before the first frame update
		void Start()
		{
			
			InitializeItems();
			InitializeUI();

			//TODO: Refacotr: move this to UIController
			_useButton.onClick.AddListener(UseCurrentItem);
			_sellButton.onClick.AddListener(SellCurrentItem);

		}

		// Update is called once per frame
		void Update()
		{

		}
		#endregion

		#region Public Methods
		public void AddItem(ItemButton itemButton)
		{
			ItemButton newItem = Instantiate(itemButton, _inventoryPanel);
			newItem.CurrentItem = itemButton.CurrentItem;
			newItem.OnClick += () => SelectItem(newItem);
		}

		public void SelectItem(ItemButton currentItem)
		{
			_selectedItem = currentItem;
			//Lógica de control de botones de acciones
			if(_selectedItem.CurrentItem is IUsable)
				_useButton.gameObject.SetActive(true);
			else
				_useButton.gameObject.SetActive(false);

			if(_selectedItem.CurrentItem is ISellable)
				_sellButton.gameObject.SetActive(true);
			else
				_sellButton.gameObject.SetActive(false);
		}
		#endregion

		#region Private Methods
		private void InitializeItems()
		{
			// Weapons
			for (int i = 0; i < _weapons.Length; i++)
				_items.Add(_weapons[i]);

			// Food
			for (int i = 0; i < _food.Length; i++)
				_items.Add(_food[i]);

			// Other
			for (int i = 0; i < _other.Length; i++)
				_items.Add(_other[i]);
		}

		private void InitializeUI()
		{
			for (int i = 0; i < _items.Count; i++)
			{
				ItemButton itemButton = Instantiate(_prefabItemButton, _prefabItemButton.transform.parent);
				itemButton.CurrentItem = _items[i];
				itemButton.OnClick += () => AddItem(itemButton);
			}
			_prefabItemButton.gameObject.SetActive(false);
		}


		//TODO: Refacotr: move this to UIController
		private void SellCurrentItem()
		{
			(_selectedItem.CurrentItem as ISellable).Sell();
			Consume(_selectedItem);
		}

		private void UseCurrentItem()
		{
			(_selectedItem.CurrentItem as IUsable).Use();
			if (_selectedItem.CurrentItem is IConsumable)
			{
				Consume(_selectedItem);
			}
		}

		private void Consume(ItemButton itemButton)
		{
			Destroy(_selectedItem.gameObject);
			_selectedItem = null;
			_sellButton.gameObject.SetActive(false);
			_useButton.gameObject.SetActive(false);

		}
		#endregion

	}

}