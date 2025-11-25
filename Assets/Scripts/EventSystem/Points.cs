using UnityEngine;
using System;

public class Points : MonoBehaviour
{    
    #region Properties
	public int CurrentPoints 
	{
		get;
		set;

	}
	public event Action OnGetPoints;
	#endregion

	#region Fields
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
			AddPoints(10);

	}
	#endregion

	#region Public Methods
	public void AddPoints(int points)
	{
		CurrentPoints += points;
		OnGetPoints?.Invoke();
	}
	#endregion

	#region Private Methods
	#endregion

}
