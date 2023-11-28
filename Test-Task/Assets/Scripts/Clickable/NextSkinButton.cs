using Clock;
using UnityEngine;

namespace Clickable
{
    public class NextSkinButton : MonoBehaviour, IClickable
    {
        [SerializeField] private int incrementedValue;
        [SerializeField] private new AudioSource audio;
    
        public void Click()
        {
            TimeParser.GetNextSkin?.Invoke(incrementedValue);
            audio.Play();
        }
    }
}
