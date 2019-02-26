using System;
using System.Collections.Generic;
using UnityEngine;

using Games.Interface;

namespace Games
{
    public class ProcessingScene : IDisposable
    {
        public static ProcessingScene Default = new ProcessingScene();

        internal static Transform Dynamic = GameObject.Find("Dynamic").transform;

        public void Dispose()
        {
            
        }
    }
}