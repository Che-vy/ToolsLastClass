using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolClassic
{

    public Dictionary<string, Stack<GameObject>> objectPool;


    #region Singleton

    private static ObjectPoolClassic instance = null;

    public static ObjectPoolClassic Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObjectPoolClassic();
            }
            return instance;
        }
    }

    #endregion


    public ObjectPoolClassic()
    {
        InitializeStacks();
        objectPool = new Dictionary<string, Stack<GameObject>>();
    }

    public object WithdrawObject(string type)
    {
        object o = null;
        if (objectPool.ContainsKey(type))
        {
            o = objectPool[type].Pop();
        }
        return o;
    }

    public void StoreObject(string type, GameObject obj)
    {
        if (objectPool.ContainsKey(type))
        {
            objectPool[type].Push(obj);
        }
        else
        {
            objectPool.Add(type, new Stack<GameObject>());
            objectPool[type].Push(obj);
        }
    }


    public void InitializeStacks()
    {
        // foreach (KeyValuePair <string, Stack<System.Type>> kv in objectPool) {
        //     kv.Value.Peek()
        //     //System.Type  t = typeof();
        //    // System.Activator.CreateInstance(t);
        //
        // }

    }

}
