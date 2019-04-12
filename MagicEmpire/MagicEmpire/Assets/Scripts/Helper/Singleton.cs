﻿using UnityEngine;

namespace Games.Helpers
{
    public class Singleton<T> : MonoBehaviour  where T: MonoBehaviour
    {
        public static T _instance;

        protected void Initialize()
        {
            if (_instance) return;
            _instance = this as T;
            DontDestroyOnLoad(_instance);
        }

 
        private static System.Object _lock = new System.Object();

        public static T Instance
        {
            get
            {
                if (ApplicationIsQuitting)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                                    "' already destroyed on application quit." +
                                    " Won't create again - returning null.");
                    return null;
                }

                lock (_lock)
                {
                    if (_instance != null) return _instance;
                    _instance = (T) FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] Something went really wrong " +
                                    " - there should never be more than 1 singleton!" +
                                    " Reopening the scene might fix it.");
                        return _instance;
                    }

                    if (_instance != null) return _instance;
                    var singleton = new GameObject();
                    _instance = singleton.AddComponent<T>();
                    singleton.name = typeof(T).Name;

                    DontDestroyOnLoad(singleton);
                    return _instance;
                }
            }
        }


        public static bool isQuittingOrChangingScene()
        {
            return ApplicationIsQuitting || ChangingScene;
        }

        public static bool ChangingScene;
        public static bool ApplicationIsQuitting;

        private void OnDisable()
        {
            ApplicationIsQuitting = true;
        }

        private void OnApplicationQuit()
        {
            ApplicationIsQuitting = true;
        }
    }
}
