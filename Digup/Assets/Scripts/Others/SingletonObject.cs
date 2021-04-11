using UnityEngine;

public abstract class SingletonObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                T[] TObjects = Resources.FindObjectsOfTypeAll<T>();

                if (TObjects.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject : results length is 0 of " + typeof(T).ToString());
                    return null;
                }

                if (TObjects.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObject : results length is greater than 1 of " + typeof(T).ToString());
                    return null;
                }

                _instance = TObjects[0];
                _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
            }
            return _instance;
        }
    } 
}
