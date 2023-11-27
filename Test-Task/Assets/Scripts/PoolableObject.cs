using System;
using System.Collections;
using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
     [SerializeField] private float poolTime;

     public bool IsInactive { get; private set; }

     private void Awake()
     {
          IsInactive = true;
     }

     public virtual void Reinitialize()
     {
          IsInactive = false;
     }
     
     protected IEnumerator TrackPool()
     {
          yield return new WaitForSeconds(poolTime);
          IsInactive = true;
     }
}
