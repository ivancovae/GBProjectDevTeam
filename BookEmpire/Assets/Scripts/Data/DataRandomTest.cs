using UnityEngine;
using Games.Interface;

namespace Games
{
    [System.Serializable]
    public class DataRandomTest : IRandom
    {
        public float chance;

        public float returnChance 
        { 
            get { return chance; }
        }

        public Transform root;
    }
}
