using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeParser : MonoBehaviour
{
    public static Action<int> GetNextSkin;
    [SerializeField] private Transform arrowH;
    [SerializeField] private Transform arrowM;
    [SerializeField] private Transform arrowS;
    [SerializeField] private TextMeshPro week;
    [SerializeField] private MeshRenderer arrowMesh;
    private int currentIndex;
    private Skin[] skins;
    private Skin skin;

    private void Awake()
    {
        GetNextSkin += OnGetNextSkin;
    }

    private void OnGetNextSkin(int i)
    {
        currentIndex += i;
        int realIndex = Mathf.Abs(currentIndex % skins.Length);
        skin = skins[realIndex];
        arrowMesh.material = skin.material;
        UpdateData();
    }

    private void OnDestroy()
    {
        GetNextSkin -= OnGetNextSkin;
    }


    private IEnumerator Start()
    { 
        skins = Resources.LoadAll<Skin>("Skins");
        skin = skins[currentIndex];
        arrowMesh.material = skin.material;
        var waitTime = new WaitForSeconds(1);
        while (true)
        {
            UpdateData();
            yield return waitTime;
        }
    }

    private void UpdateData()
    {
        DateTime gmtTime = DateTime.UtcNow.AddHours(skin.offset);
        week.text = skin.daysName[(int)gmtTime.DayOfWeek];
    
        float rotationAngleXHour = -gmtTime.Hour % 12 * (360f / 12f);
        float rotationAngleXMinute = -gmtTime.Minute * (360f / 60f);
        float rotationAngleXSecond = -gmtTime.Second * (360f / 60f);
    
        arrowH.localRotation = Quaternion.Euler(rotationAngleXHour, 0f, 0f);
        arrowM.localRotation = Quaternion.Euler(rotationAngleXMinute, 0f, 0f);
        arrowS.localRotation = Quaternion.Euler(rotationAngleXSecond, 0f, 0f);
    }
}
