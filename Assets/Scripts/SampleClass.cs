using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class SampleClass<T> : MonoBehaviour {

    public int[] kk;
    public List<int> jj;
    public Stack<int> ww;

	// Use this for initialization
	void Start () {
        SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;


        System.Type ttype = typeof(Werewolf);
        CreateMonsterOfType<Werewolf>();


        Vector4 v4 = (Vector4)System.Activator.CreateInstance(typeof(Vector4), new object[] { 1f, 2f, 3f, 4f });
        Debug.Log("activator : " + v4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public T CreateMonsterOfType<T>() {
        System.Type ttype = typeof(T);
       // if (ttype.IsSubclassOf(typeof(Monster)))
       // {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            g.AddComponent<Rigidbody>();
            //g.AddComponent<MeshRenderer>();
            //g.AddComponent<BoxCollider2D>();
            //g.AddComponent<MeshCollider>();
            return (T)System.Convert.ChangeType(g.AddComponent(ttype), ttype);
           // return g.GetComponent<Monster>();
       // }
      //else {
      //    Debug.Log(string.Format("Wrong monster type passed as argument {0}", ttype));
      //     //return null;
      //    //return (T)System.Convert.ChangeType(g.AddComponent(ttype), ttype);
      //
      //}
    }

    

}
