using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SerializableDictionary<string, System.Collections.Stack>;

[System.Serializable]
public class MainFlow : MonoBehaviour {
    private Dictionary<string, Texture> textureList;

    public ObjectPool op; 

    // Use this for initialization
    void Start () {
        textureList = new Dictionary<string, Texture>();
        //BulletFactory.Instance.ToString();
        //textureList = BulletFactory.Instance.typeList;
        op = new ObjectPool(GenericClassCreator.GetAllFileNamesInFolder(Application.dataPath + "/Resources/Textures", "png"));


        // BulletFactory.Instance.SpawnObject("Bullet_9mm.prefab");
        //BulletFactory.Instance.SpawnObject("Bullet_9mm");

        BulletFactory.Instance.ToString();
        
        foreach (KeyValuePair<string, System.Type> kv in op.typeList) {
            BulletFactory.Instance.SpawnObject(kv.Key);


        }
      // BulletFactory.Instance.SpawnObject("Bullet_9mm");
      // BulletFactory.Instance.SpawnObject("Bullet_9mm");
      // BulletFactory.Instance.SpawnObject("Bullet_9mm");
      // BulletFactory.Instance.SpawnObject("Bullet_9mm");
      // BulletFactory.Instance.SpawnObject("Bullet_9mm.prefab");


    }

    // Update is called once per frame
    void Update () {
		
	}
}
