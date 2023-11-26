using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeParser : MonoBehaviour
{
    [SerializeField] private Transform arrowH;
    [SerializeField] private Transform arrowM;
    [SerializeField] private Transform arrowS;
    [SerializeField] private TextMeshPro week;
    [SerializeField] private MeshRenderer arrowMesh;
    private Skin[] skins;
    private Skin skin;
    
    
    private IEnumerator Start()
    { 
        skins = Resources.LoadAll<Skin>("Skins");
        Debug.Log(skins.Length);
        var waitTime = new WaitForSeconds(1);
        while (true)
        {
            DateTime gmtTime = DateTime.UtcNow;
            week.text = ((int)gmtTime.DayOfWeek).ToString();
    
            float rotationAngleXHour = -gmtTime.Hour % 12 * (360f / 12f);
            float rotationAngleXMinute = -gmtTime.Minute * (360f / 60f);
            float rotationAngleXSecond = -gmtTime.Second * (360f / 60f);
    
            arrowH.localRotation = Quaternion.Euler(rotationAngleXHour, 0f, 0f);
            arrowM.localRotation = Quaternion.Euler(rotationAngleXMinute, 0f, 0f);
            arrowS.localRotation = Quaternion.Euler(rotationAngleXSecond, 0f, 0f);
            yield return waitTime;
        }
    }
}
