﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keys = new List<TKey>();

    [SerializeField]
    private List<TValue> values = new List<TValue>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        this.Clear();

        if (keys.Count != values.Count)
            throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable.", keys.Count, values.Count));

        for (int i = 0; i < keys.Count; i++)
            this.Add(keys[i], values[i]);
    }



    [System.Serializable]
    public class ObjectPool : SerializableDictionary<string, Stack<System.Type>>
    {

        public Dictionary<string, System.Type> typeList = new Dictionary<string, System.Type>();


        public ObjectPool(string[] _fileNames)
        {

            typeList = GenericClassCreator.GetAllTypesFromFileNames(_fileNames);
            

            foreach (string s in _fileNames)
            {
                System.Type t;
                typeList.TryGetValue(s, out t);

                if (t != null)
                {
                    keys.Add(s);
                    //values.Add(t);

                }


            }
        }
    }
}
