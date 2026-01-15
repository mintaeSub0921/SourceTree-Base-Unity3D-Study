using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;
using System;


public class PoolManager : SingletonCore<PoolManager>
{
    [Serializable]
    public class PoolData
    {
        public string name;
        public GameObject prefab;

    }

    public List<PoolData> poolList = new List<PoolData>();
    private Dictionary<string, IObjectPool<GameObject>> poolDics = new Dictionary<string, IObjectPool<GameObject>>();


    protected override void Awake()
    {
        base.Awake();

        foreach (var poolData in poolList)
        {
            poolDics[poolData.name] = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(poolData.prefab), // 생성하는 기능
                actionOnGet: (obj) => obj.SetActive(true), // 꺼내는 기능
                actionOnRelease: (obj) => obj.SetActive(false)); // 넣는 기능

        }
    }

    public GameObject GetObject(string key)
    {
        if (poolDics.ContainsKey(key))
        {

            GameObject obj = poolDics[key].Get();

            return obj;
        }

        Debug.LogError($"Pool {key} has not founded");
        return null;
    }

    public void ReleaseObject(string key, GameObject obj)
    {
        if (poolDics.ContainsKey(key))
            poolDics[key].Release(obj);
        else
            Debug.LogError($"Pool {key} has not founded");

    }

}

