using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectList : ScriptableObject
{
    private List<GameObject> objectList = new List<GameObject>();

    public List<GameObject> CurrentObjectList { get { return objectList; } }

    public void RegisterObject(GameObject obj)
    {
        if (!objectList.Contains(obj))
            objectList.Add(obj);
    }

    public void UnregisterObject(GameObject obj)
    {
        if (objectList.Contains(obj))
            objectList.Remove(obj);
    }

    public void ClearList()
    {
        objectList.Clear();
    }
}
