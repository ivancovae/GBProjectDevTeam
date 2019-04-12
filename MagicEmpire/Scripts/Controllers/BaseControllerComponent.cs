using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games.Controller
{
    public class BaseControllerComponent : MonoBehaviour
    {
        protected virtual void Awake()
        {
                
        }

        public bool Enabled { get; private set; }

        public virtual void On()
        {
            if (Enabled)
                return;
            Enabled = true;
        }

        public virtual void Off()
        {
            if (!Enabled)
                return;
            Enabled = false;
        }

        public virtual void Switch()
        {
            if (Enabled)
            {
                Off();
            }
            else
            {
                On();
            }
        }
    }
}