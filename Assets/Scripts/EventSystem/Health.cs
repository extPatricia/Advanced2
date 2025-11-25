using UnityEngine;
using System;

public class Health : MonoBehaviour
{    
    #region Properties
	public float CurrentHealth 
	{ 
		get {  return _currentHealth; }
		set { 
			if (value < 0)
			{ 
				_currentHealth = 0;
				Die();
			}
			else
				_currentHealth = value;

			if (_currentHealth > _maxHealth)
				_currentHealth = _maxHealth;
		}
	
	}

	public event Action OnDeath;
	public event Action OnGetHealth;
	public event Action OnTakeDamage;
	#endregion

	#region Fields
	[SerializeField] private float _maxHealth = 100f; 
	private float _currentHealth = 100f;
	private bool _isDead = false;

	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        CurrentHealth = _maxHealth;

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
			TakeDamage(20f);
		if (Input.GetKeyUp(KeyCode.H))
			GetHealth(20f);

	}
	#endregion

	#region Public Methods
	public void TakeDamage(float damage)
	{
		if (!_isDead)
		{

			CurrentHealth -= damage;
			if (CurrentHealth < 0)
			{
				CurrentHealth = 0;
			}

			OnTakeDamage?.Invoke();
		}
	}

	public void GetHealth(float health)
	{
		if (!_isDead)
		{
			CurrentHealth += health;

			// Event Emitter
			OnGetHealth?.Invoke();
		}
		
	}
	#endregion

	#region Private Methods
	private void Die()
	{
		if (!_isDead)
		{
			_isDead = true;
			// Event Emitter
			OnDeath?.Invoke();
		}
			
		
	}
	#endregion

}
