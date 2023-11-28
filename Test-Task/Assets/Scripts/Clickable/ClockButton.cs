using Pooling;
using UnityEngine;

namespace Clickable
{
    public class ClockButton : MonoBehaviour, IClickable
    {
        [SerializeField] private float upForce = 2;
        [SerializeField] private float sphereForce = 0.5f;

        public void Click()
        {
            PoolableObject poolableObject = PoolingManager.Instance.GetPooledObject<MetallicSphere>();
            poolableObject.transform.position = transform.position;

            ((MetallicSphere)poolableObject).Reinitialize();
            
            Vector3 sphere = Random.insideUnitSphere;
            sphere.y = 0;
            sphere = sphere.normalized;
            Vector3 localUp = transform.TransformDirection(new Vector3(0, 1, 0));
            ((MetallicSphere)poolableObject).AddForce(localUp * upForce + sphere * sphereForce);
        }
    }
}
