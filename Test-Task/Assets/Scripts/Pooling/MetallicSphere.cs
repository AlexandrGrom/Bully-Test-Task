using UnityEngine;

namespace Pooling
{
    [RequireComponent(typeof(Rigidbody))]
    public class MetallicSphere : PoolableObject
    {
        [SerializeField] private new Rigidbody rigidbody;
        private Coroutine coroutine;
        private void Reset()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void AddForce(Vector3 force)
        {
            rigidbody.AddForce(force, ForceMode.Impulse);
        }

        public override void Reinitialize()
        {
            base.Reinitialize();
        
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            coroutine = StartCoroutine(TrackPool());
        
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

    }
}
