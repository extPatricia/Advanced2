using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Slider _slider;
	[SerializeField] private TextMeshProUGUI _textPoints;
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
	public void UpdateHealthBar(float currentHealth)
	{
		_slider.value = currentHealth;
	}
	public void UpdatePoints(float currentPoints)
	{
		_textPoints.text = currentPoints.ToString();
	}
	#endregion

	#region Private Methods
	#endregion

}
