using UnityEngine;
using System;
using TMPro;

public class UIMoneyController : MonoBehaviour
{    
    #region Properties
	#endregion

	#region Fields
	[SerializeField] private TextMeshProUGUI _moneyText;
	private float _currentMoney = 0f;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	private void OnEnable()
	{
		InventoryEventSystem.Instance.OnMoneyGained += UpdateMoney;
	}

	private void OnDisable()
	{
		InventoryEventSystem.Instance.OnMoneyGained -= UpdateMoney;
	}

	private void UpdateMoney(float money)
	{
		_currentMoney += money;
		_moneyText.text = _currentMoney.ToString();
	}

	#endregion

}
