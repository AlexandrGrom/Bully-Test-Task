using UnityEngine;

public class ClockButton : MonoBehaviour, IClickable
{
    [SerializeField] private float upForce = 2;
    [SerializeField] private float sphereForce = 0.5f;

    public void Click()
    {
        PoolableObject poolableObject = PoolingManager.Instance.GetPooledObject<MetallicSphere>();
        poolableObject.transform.position = transform.position;


        ((MetallicSphere)poolableObject).Reinitialize();
        ((MetallicSphere)poolableObject).AddForce((transform.up * upForce) + Random.insideUnitSphere * sphereForce);

    }
}
