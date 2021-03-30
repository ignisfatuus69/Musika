using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SingletonManager : MonoBehaviour
{
    public static SingletonManager instance;
    //public static SingletonManager instance;
    
    public Dictionary<System.Type, MonoBehaviour> instances { get; private set; } = new Dictionary<System.Type, MonoBehaviour>();
    public List<GameObject> singletonInstances = new List<GameObject>();

    private void Awake()
    {
        instance = this;

        SceneManager.sceneUnloaded += ClearInactiveInstances;
    }

    public static void RegisterSingleton<T>(T ComponentClass) where T: MonoBehaviour
    {
        //Check and delete first if instance already exists
        if(instance.instances.ContainsValue(ComponentClass))
        {
            instance.instances.Remove(ComponentClass.GetType());
        }

        instance.instances.Add(ComponentClass.GetType(),ComponentClass);
        //instance.singletonInstances.Add(ComponentClass.gameObject);
     
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
            Debug.Log(typeof(T));
            return (T)instance.instances[typeof(T)];
        }
        else if (!instance.instances.ContainsKey(typeof(T)))
        {
            Debug.LogError("Singleton Instance does not exist");
            return null;
        }
        else return null;
    }

    private void ClearInactiveInstances(Scene scene)
    {
        Debug.Log(instances.Count);
        //for (int i = 0; i < instance.singletonInstances.Count; i++)
        //{
        //    if (instance.singletonInstances[i].activeInHierarchy)
        //    {
        //        Destroy(instance.singletonInstances[i]);
        //        instance.singletonInstances.RemoveAt(i);
        //    }
        //}
    }

  
    
}
