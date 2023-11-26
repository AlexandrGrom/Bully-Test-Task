using System;
using UnityEngine;

public class CylinderAnimation : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed = 3;
    [SerializeField] private float floatingSpeed = 3;
    [SerializeField] private float floatingRange = 3;

    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.localPosition;
    }

    private void Update()
    {
        transform.localRotation = Quaternion.Euler(0, (Time.time * rotatingSpeed),0);
        transform.localPosition = startPosition + Vector3.up * (Mathf.Sin(Time.time * floatingSpeed) * floatingRange);
    }
}
