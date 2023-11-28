using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "Skins", menuName = "Skin")]

    public class Skin : ScriptableObject
    {
        public Material material;
        public int size;
        public string[] daysName;
        [Range(-12, 12)] public int offset;
    }
}
