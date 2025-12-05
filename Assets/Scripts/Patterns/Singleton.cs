using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;
	private static bool _shuttingDown = false;
	private static object _lock = new object();

	public static T Instance
	{
		get
		{
			if (_shuttingDown)
			{
				Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");
				return null;
			}

			lock (_lock)
			{
				if (_instance == null)
				{
					_instance = FindObjectOfType<T>();

					if (_instance == null)
					{
						var singletonObj = new GameObject($"{typeof(T)} (Singleton)");
						_instance = singletonObj.AddComponent<T>();
						DontDestroyOnLoad(singletonObj);
					}
				}

				return _instance;
			}
		}
	}

	protected virtual void OnApplicationQuit()
	{
		_shuttingDown = true;
	}

	protected virtual void OnDestroy()
	{
		_shuttingDown = true;
	}
}
