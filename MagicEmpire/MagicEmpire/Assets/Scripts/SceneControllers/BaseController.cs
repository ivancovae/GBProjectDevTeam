using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    public bool Enabled { get; private set; }  
    public virtual void On() { if (Enabled) return; Enabled = true; }
    public virtual void Off() { if (!Enabled) return; Enabled = false; }
    public virtual void Switch() { if (Enabled) Off(); else On(); }
}
