using UnityEngine;

namespace Games
{
    [CreateAssetMenu(fileName = "New case", menuName = "Book case")]
    public class DataBookCase : ScriptableObject
    {
        public string Name;
        public int Id;
        [Multiline] public string Description;
        public Sprite Icon;
        public BookCase PrefabBookCase;
    }
}