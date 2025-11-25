using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettersSetters : MonoBehaviour
{

	#region Properties
	public int Points { get; set; }
	public int LevelPoints
	{
		get { return _levelPoints; }
		set { _levelPoints = value; }
	}

	// Delegate property example	
	//public int LevelPoints => _levelPoints;
	#endregion

	#region Fields
	private int _levelPoints = 1000;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
	{
		Points = 10;
		Debug.Log("Points: " + Points);
		_levelPoints *= 2;
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
