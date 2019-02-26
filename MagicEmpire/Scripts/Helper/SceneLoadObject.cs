using System;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Helpers
{
    [CreateAssetMenu(fileName = "SceneLoad", menuName = "Scenes/Scene Object")]
    public class SceneLoadObject : ScriptableObject
    {
        public List<SceneField> sceneToKeep;
        public List<SceneField> sceneDependsOn;
        public Starter starter;
    }
}