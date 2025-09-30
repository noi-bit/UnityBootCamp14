using UnityEngine;

public class ResourceManager
{
    public T[] LoadAll<T>(string path) where T : Object
    {
        return Resources.LoadAll<T>(path); ;
    }
}
