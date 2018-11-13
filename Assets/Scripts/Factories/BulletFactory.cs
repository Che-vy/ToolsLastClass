using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory
{

    public Dictionary<string, Stack<GameObject>> typeList = new Dictionary<string, Stack<GameObject>>();
    public Dictionary<string, System.Type> tlist = new Dictionary<string, System.Type>();

    #region Singleton

    private static BulletFactory instance = null;

    public static BulletFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BulletFactory();
            }
            return instance;
        }
    }

    #endregion

    private BulletFactory()
    {
        tlist = GenericClassCreator.GetAllTypesFromFileLocation(Application.dataPath + "/Resources/Textures");

    }

    public void SpawnObject(string type)
    {
        object o = ObjectPoolClassic.Instance.WithdrawObject(type);
        if (o != null)
        {
            typeList[type].Push((GameObject)o);
        }
        else
        {
            Debug.Log(type);
            if (typeList.ContainsKey(type))
            {
                typeList[type].Push(GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/" + type)));
            }
            else
            {
                typeList.Add(type, new Stack<GameObject>());
                typeList[type].Push(GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/" + type)));
            }
        }
    }

    public void StoreObject(string type, GameObject go)
    {
        ObjectPoolClassic.Instance.StoreObject(type, go);
    }


    public void InitializeObject(object obj) { }

    public void DeactivateObject(object obj) { }


}
