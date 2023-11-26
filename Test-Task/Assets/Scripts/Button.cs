using UnityEngine;

public class Button : MonoBehaviour, IClickable
{
    [SerializeField] private int incrementedValue;
    
    public void Click()
    {
        TimeParser.GetNextSkin?.Invoke(incrementedValue);
    }
}
