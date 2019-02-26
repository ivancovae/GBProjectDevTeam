using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Games
{
    // Поведение магазина на карте
    public class ShopOnMap : BaseObjectScene
    {
        [SerializeField] private Sprite selected;
        [SerializeField] private Sprite _default;
        protected override void Awake()
        {
            base.Awake();
            _default = _renderer.sprite;
        }

        public void SelectShop()
        {
            if (selected != null)
                _renderer.sprite = selected;
        }

        public void DeselectShop()
        {
            _renderer.sprite = _default;
        }

        public override void Tick()
        {
            base.Tick();
        }
    }
}