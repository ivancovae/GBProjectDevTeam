using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    public abstract class BaseObjectScene : MonoBehaviour
    {
        protected Vector3 _position;
        protected GameObject _instanceObject;
        protected SpriteRenderer _renderer;
        protected Transform _view;
        protected string _name;
        protected bool _isVisible;

#region UnityFunction
        protected virtual void Awake ()
        {
            _instanceObject = gameObject;
            _name = _instanceObject.name;
            _view = transform.Find("view");
            if (_view)
            {
                _renderer = _view.GetComponent<SpriteRenderer>();
            }
        }
#endregion
#region Property
        public GameObject InstanceObject => _instanceObject;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                InstanceObject.name = _name;
            }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                if (_renderer)
                    _renderer.enabled = _isVisible;
            }
        }
        public Vector3 Position
        {
            get
            {
                if (InstanceObject != null )
                {
                    _position = transform.position;
                }
                return _position;
            }
            set
            {
                _position = value ;
                if (InstanceObject != null )
                {
                    transform.position = _position;
                }
            }
        }
#endregion
    }
}