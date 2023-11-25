using System;
using UnityEngine;

public class TimeParser : MonoBehaviour
{
    [SerializeField] private Transform arrowH;
    [SerializeField] private Transform arrowM;
    [SerializeField] private Transform arrowS;
    
    
    private void Update()
    {
        DateTime gmtTime = DateTime.UtcNow;

        float rotationAngleXHour = -gmtTime.Hour % 12 * (360f / 12f);
        float rotationAngleXMinute = -gmtTime.Minute * (360f / 60f);
        float rotationAngleXSecond = -gmtTime.Second * (360f / 60f);

        arrowH.localRotation = Quaternion.Euler(rotationAngleXHour, 0f, 0f);
        arrowM.localRotation = Quaternion.Euler(rotationAngleXMinute, 0f, 0f);
        arrowS.localRotation = Quaternion.Euler(rotationAngleXSecond, 0f, 0f);
    }
}
