using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)(object)this; // Cast to T
            DontDestroyOnLoad(gameObject); // Keep this instance across scenes
        }
        else
        {
            Debug.LogWarning($"An instance of {typeof(T).Name} already exists. Destroying the new instance.");
            Destroy(gameObject); // Destroy the new instance if one already exists
        }
    }
}
