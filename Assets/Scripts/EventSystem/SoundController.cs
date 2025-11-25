using UnityEngine;
using System;

public class SoundController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private AudioClip _damageSound;
	[SerializeField] private AudioClip _deathSound;
	[SerializeField] private AudioClip _pointsSound;
	private AudioSource _audioSource;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        _audioSource = GetComponent<AudioSource>();
	}

	#endregion

	#region Public Methods
	public void PlayDamageSound()
	{
		_audioSource.clip = _damageSound;
		_audioSource.Play();
		//AudioSource.PlayClipAtPoint(_damageSound, transform.position);
	}

	public void PlayDeathSound()
	{
		_audioSource.clip = _deathSound;
		_audioSource.Play();

	}

	public void PlayPointsSound()
	{
		_audioSource.clip = _pointsSound;
		_audioSource.Play();
	}
	#endregion

	#region Private Methods
	#endregion

}
