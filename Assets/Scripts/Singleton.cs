using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static object @lock = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            lock (@lock)
            {
                if (instance == null)
                {
                    // Search for existing instance.
                    instance = (T)FindObjectOfType(typeof(T));

                    // Create new instance if one doesn't already exist.
                    if (instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        // Make instance persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return instance;
            }
        }
    }

    private void OnApplicationQuit()
    {
        instance = null;
    }


    private void OnDestroy()
    {
         instance = null;
    }
}

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T instance = null;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                T[] all = Resources.FindObjectsOfTypeAll<T>();
                instance = (all.Length > 0) ? all[0] : null;
            }
            return instance;
        }
    }
}
