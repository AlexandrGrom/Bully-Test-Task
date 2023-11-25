using UnityEngine;

public class CylinderAnimation : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed = 3;
    [SerializeField] private float floatingSpeed = 3;
    [SerializeField] private float floatingRange = 3;
    private void Update()
    {
        transform.Rotate(transform.up, Time.deltaTime * rotatingSpeed);
        //transform.position = Vector3.up * (Mathf.Sin(Time.time * floatingSpeed) * floatingRange);
    }
}
