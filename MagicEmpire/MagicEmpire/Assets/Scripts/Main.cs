using UnityEngine;
using UnityEngine.SceneManagement;
using Games.Controller;

namespace Games
{
    public sealed class Main : MonoBehaviour
    {
        private GameObject _allControllers;

        private void Awake()
        {
            Instance = this;
            _allControllers = new GameObject { name = "Controllers" };
            InventoryController = _allControllers.AddComponent<InventoryController>();
            InputController = _allControllers.AddComponent<InputController>();

            ObjectManager = _allControllers.AddComponent<ObjectManager>();
        }
        #region Property

         public InventoryController InventoryController { get; private set; }
         public InputController InputController { get; private set; }
         public ObjectManager ObjectManager { get; private set; }

        public static Main Instance { get; private set; }
        #endregion
    }
}