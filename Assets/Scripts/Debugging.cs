using UnityEngine;
using System;

public class Debugging : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[Header("Gizmo Lines")]
	[SerializeField] private Vector3 initialGizmoLine;
	[SerializeField] private Vector3 finalGizmoLine;
	[Header("Vision Areas")]
	[SerializeField] private float _visionLenght = 5f;
	[Header("Detection Areas")]
	[SerializeField] private float _visionArea = 10f;
	[SerializeField] private float _audioArea = 30f;

	private int _count = 0;
	#endregion

	#region Unity Callbacks
	// Start is called before the first frame update
	void Start()
    {
		Debug.Log("Mensaje");
		Debug.LogWarning("Mensaje de advertencia");
		Debug.LogError("Mensaje de error");
	}

	// Update is called once per frame
	void Update()
	{
		_count++;
		if (_count % 100 == 0)
		{
			Debug.Log("Contador: " + _count);
		}
	}
	#endregion

	#region Public Methods
	#endregion

	#region Private Methods
	#endregion

	#region Gizmos
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawLine(initialGizmoLine, finalGizmoLine);
		Gizmos.DrawWireSphere(Vector3.zero, _visionArea);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(Vector3.zero, (Vector3.forward + Vector3.right) * _visionLenght);
		Gizmos.DrawLine(Vector3.zero, (Vector3.forward + Vector3.left) * _visionLenght);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(Vector3.zero, _audioArea);
	}
	#endregion

}
