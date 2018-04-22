using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool> {

    //资源目录
    public string ResourceDir = "";

    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();

    //取物体
    public GameObject Spawn(string name, Transform trans)
    {
        SubPool pool = null;
        if (!m_pools.ContainsKey(name)) {
            RegisterNew(name, trans);
        }

        pool = m_pools[name];
        return pool.Spawn();
    }

    //回收物体
    public void Unspawn(GameObject go)
    {
        SubPool pool = null;
        foreach (var p in m_pools.Values)
        {
            if (p.Contain(go)) {
                pool = p;
                break;
            }
        }
        pool.UnSpawn(go);
    }

    //回收所有物体
    public void UnspawnAll()
    {
        foreach (var p in m_pools.Values) {
            p.UnSpawnAll();
        }
    }

    void RegisterNew(string names, Transform trans)
    {
        //资源目录
        string path = ResourceDir + "/" + names;
        //生成目录
        GameObject go = Resources.Load<GameObject>(path);
        SubPool pool = new SubPool(trans, go);
        m_pools.Add(pool.Name, pool);

    }
	
}
