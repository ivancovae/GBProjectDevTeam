using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    public abstract class BaseObjectScene : MonoBehaviour
    {
        protected Vector3 _position;
        protected Quaternion _rotation;
        protected Vector3 _scale;
        protected GameObject _instanceObject;
        protected Transform _transform;
        protected SpriteRenderer _renderer;
        protected Transform _view;
        protected string _name;
        protected bool _isVisible;

#region UnityFunctions
        protected virtual void Awake ()
        {
            _instanceObject = gameObject;
            _name = _instanceObject.name;
            _transform = transform;
            _view = _transform.Find("view");
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
            get => _name;
            set
            {
                _name = value;
                InstanceObject.name = _name;
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
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
                    _position = _transform.position;
                }
                return _position;
            }
            set
            {
                _position = value ;
                if (InstanceObject != null )
                {
                    _transform.position = _position;
                }
            }
        }

        public Quaternion Rotation
        {
            get
            {
                if (InstanceObject != null )
                {
                    _rotation = _transform.rotation;
                }
                return _rotation;
            }
            set
            {
                _rotation = value ;
                if (InstanceObject != null )
                {
                    _transform.rotation = _rotation;
                }
            }
        }

        public Vector3 Scale
        {
            get
            {
                if (InstanceObject != null )
                {
                    _scale = _transform.localScale;
                }
                return _scale;
            }
            set
            {
                _scale = value ;
                if (InstanceObject != null )
                {
                    _transform.localScale = _scale;
                }
            }
        }
        public Transform Transform => _transform;

#endregion
    }
}