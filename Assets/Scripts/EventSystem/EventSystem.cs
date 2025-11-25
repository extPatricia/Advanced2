using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Points _points;
	[SerializeField] private Health _playerHealth;
	[SerializeField] private UIController _ui;
	[SerializeField] private SoundController _soundController;

	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		// Event listeners
		_playerHealth.OnTakeDamage += OnTakeDamage;
		_playerHealth.OnGetHealth += OnGetHealth;
		_playerHealth.OnDeath += OnDeath;
		_points.OnGetPoints += OnAddPoints;
	}

	
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods

	private void OnTakeDamage()
	{
		_soundController.PlayDamageSound();
		_ui.UpdateHealthBar(_playerHealth.CurrentHealth);
	}

	private void OnDeath()
	{
		_soundController.PlayDeathSound();
		Debug.Log("Player Died");
		Destroy(_playerHealth.gameObject);
	}
	private void OnGetHealth()
	{
		_ui.UpdateHealthBar(_playerHealth.CurrentHealth);
	}
	
	private void OnAddPoints()
	{
		_ui.UpdatePoints(_points.CurrentPoints);
		_soundController.PlayPointsSound();
	}

	#endregion

}
