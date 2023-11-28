using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pooling
{
    public class PoolingManager : MonoBehaviour
    {
        public static PoolingManager Instance { get; private set; }
    
        [SerializeField] private PoolableObject[] prefab;
        [SerializeField] private int poolSize = 10;
    
        private Dictionary<Type, List<PoolableObject>> objectPool;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            objectPool = new Dictionary<Type, List<PoolableObject>>();
        
            InitializeObjectPool();
        }

        void InitializeObjectPool()
        {
            for (int j = 0; j < prefab.Length; j++)
            {
                objectPool.Add(prefab[j].GetType(), new List<PoolableObject>());
            
                for (int i = 0; i < poolSize; i++)
                {
                    PoolableObject obj = Instantiate(prefab[j]);
                    obj.gameObject.SetActive(false);
                    objectPool[obj.GetType()].Add(obj);
                }
            }
        }

        public PoolableObject GetPooledObject<T>() where T : PoolableObject
        {
            var poolableObjects = objectPool[typeof(T)];
            for (int i = 0; i < poolableObjects.Count; i++)
            {
                if (!poolableObjects[i].IsInactive) continue;
            
                poolableObjects[i].gameObject.SetActive(true);
                return poolableObjects[i];
            }

            int idx = 0;
            for (int i = 0; i < prefab.Length; i++)
            {
                if (prefab[i].GetType() != typeof(T)) continue;
                idx = i;
                break;
            }

            PoolableObject newObj = Instantiate(prefab[idx]);
            objectPool[typeof(T)].Add(newObj);
            return newObj;
        }

    }
}
