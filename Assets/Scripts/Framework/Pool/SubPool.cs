using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SubPool
{
    List<GameObject> m_objects = new List<GameObject>();

    //预设
    GameObject m_prefab;

    //名字
    public string Name {
        get {
            return m_prefab.name;
        }
    }

    Transform m_parent;

    public SubPool(Transform parent, GameObject go) {
        m_parent = parent;
        m_prefab = go;
    }

    //取出物体
    public GameObject Spawn()
    {
        GameObject go = null;
        foreach (var obj in m_objects) {
            if (obj.activeSelf) {
                go = obj;
            }
        }

        if (go == null) {
            go = GameObject.Instantiate<GameObject>(m_prefab);
            go.transform.parent = m_parent;
            m_objects.Add(go);
        }

        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

        return go;
    }
    
    //回收物体
    public void UnSpawn(GameObject go)
    {
        if (m_objects.Contains(go)) {
            go.SendMessage("OnUnSpawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    //回收所有物体
    public void UnSpawnAll()
    {
        foreach (var obj in m_objects)
        {
            if (obj.activeSelf)
            {
                UnSpawn(obj);
            }
        }
    }

    public bool Contain(GameObject go)
    {
        return m_objects.Contains(go);
    }
}

