using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable {

    public Rigidbody rb;
    public MeshCollider mc;
    public MeshRenderer mr;
    public string type;


    public void Pool()
    {
        BulletFactory.Instance.StoreObject(type, gameObject);
        gameObject.SetActive(false);
    }

    public void Depool()
    {
        gameObject.SetActive(true);
    }

    public void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        mc = GetComponent<MeshCollider>();
        mr = GetComponent<MeshRenderer>();
    }
}
