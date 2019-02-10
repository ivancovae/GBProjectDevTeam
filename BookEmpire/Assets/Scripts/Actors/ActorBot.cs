using UnityEngine;
using Games.Interface;
using Games.Managers;

namespace Games
{
    public class ActorBot : MonoBehaviour, ITick
    {
        private void Awake() 
        {
            ManagerUpdate.AddTo(this);
        }
        public void Tick()
        {
            Debug.Log("I`m an ActorBot");
        }
    }
}