using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SingletonManager : MonoBehaviour
{
    public static SingletonManager instance;
    //public static SingletonManager instance;
    public Dictionary<System.Type, MonoBehaviour> instances { get; private set; } = new Dictionary<System.Type, MonoBehaviour>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(instance);
            instance = this;
        }

        SceneManager.sceneUnloaded += ClearInactiveInstances;
    }

    public static void RegisterSingleton<T>(T ComponentClass) where T: MonoBehaviour
    {
        //Check first if may ganon
        if(instance.instances.ContainsValue(ComponentClass))
        {
            instance.instances.Remove(ComponentClass.GetType());
        }
        instance.instances.Add(ComponentClass.GetType(),ComponentClass);
    }

    public static void UnregisterSingleton<T>(T ComponentClass) where T:MonoBehaviour
    {
        if (instance.instances.ContainsValue(ComponentClass))
        {
            instance.instances.Remove(ComponentClass.GetType());
        }
    }

    public static T GetSingleton<T>() where T:MonoBehaviour
    {
        if (instance.instances.ContainsKey(typeof(T)))
        {
            return (T)instance.instances[typeof(T)];
        }
        else return null;
    }

    private void ClearInactiveInstances(Scene scene)
    {
        foreach (KeyValuePair<System.Type, MonoBehaviour> instance in instance.instances)
        {
            if (instance.Value == null || instance.Key == null) instances.Remove(instance.Key);
        }
    }

  
    
}
