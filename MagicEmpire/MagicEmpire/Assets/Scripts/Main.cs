using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Games.Controller;
using Games.Helpers;

namespace Games
{
    public class Main : Singleton<Main>
    {
        private GameObject _controllersGO;
        private InputController _inputController;
        private ShopsController _shopsController;
        private PositioningController _positioningController;
        private ObjectManager _objectManager;

        [System.Serializable]
        public struct SceneDate
        {
            public SceneField GlobalMapScene;
            public SceneField ShopScene;
        }

        public SceneDate Scenes;
        private SceneField _CurrentScene;

        protected Main() {}

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _objectManager = transform.GetComponent<ObjectManager>();
            InitGlobalMap();
        }

        public void InitGlobalMap()
        {
            _controllersGO = new GameObject { name = "Controllers"};
            _inputController = _controllersGO.AddComponent<InputController>();
            _shopsController = _controllersGO.AddComponent<ShopsController>();
            _positioningController = _controllersGO.AddComponent<PositioningController>();
        }

        public void InitShop()
        {
            _controllersGO = new GameObject { name = "Controllers"};
            _inputController = _controllersGO.AddComponent<InputController>();
            _shopsController = _controllersGO.AddComponent<ShopsController>();
            _positioningController = _controllersGO.AddComponent<PositioningController>();
        }

        public InputController InputController => _inputController;
        public ShopsController ShopsController => _shopsController;
        public PositioningController PositioningController => _positioningController;
        public ObjectManager ObjectManager => _objectManager;
    }
}