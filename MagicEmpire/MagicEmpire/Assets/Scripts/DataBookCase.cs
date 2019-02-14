using UnityEngine;

namespace Games
{
    [System.Serializable]
    public class DataBookCase
    {
        public string Name;
        public int Id;
        [Multiline] public string Description;
        public Sprite Icon;
        public BookCase PrefabBookCase;
        public bool Used;
    }
}