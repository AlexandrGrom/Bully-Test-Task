using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private new Camera camera;

    private void Reset()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out var hit)) 
            {
                if (hit.collider.TryGetComponent(out IClickable clickable))
                {
                    clickable.Click();
                }
            }
        }
    }
}