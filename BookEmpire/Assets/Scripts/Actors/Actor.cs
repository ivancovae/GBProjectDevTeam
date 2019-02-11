using UnityEngine;
using Games.Interface;

namespace Games
{
    public class Actor : MonoBehaviour, ITick
    {
        public virtual void Tick()
        {
            
        }
    }
}