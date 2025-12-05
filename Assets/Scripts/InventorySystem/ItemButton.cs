using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

namespace Inventory
{

	public class ItemButton : MonoBehaviour
	{
		#region Properties
		public Item CurrentItem  { 
			get { return _currentItem; }
			set 
			{ 
				_currentItem = value;
				//_buttonText.text = _currentItem.Name;
				_button.image.sprite = _currentItem.Icon;
			}
		}
		public event Action<ItemButton> OnClick;
		#endregion

		#region Fields
		private Button _button;
		private TextMeshProUGUI _buttonText;
		private Item _currentItem;
		#endregion

		#region Unity Callbacks
		// Start is called before the first frame update
		void Awake()
		{
			_button = GetComponent<Button>();
			_buttonText = GetComponentInChildren<TextMeshProUGUI>();
			// Delegate example
			_button.onClick.AddListener(() => OnClick?.Invoke(this));
		}

		// Update is called once per frame
		void Update()
		{

		}
		#endregion

		#region Public Methods
		#endregion

		#region Private Methods
		#endregion

	}

}