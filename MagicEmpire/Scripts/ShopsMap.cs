using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Games.Controller;

namespace Games
{
    // Поведение карты магазинов
    public class ShopsMap : BaseObjectScene
    {
        [SerializeField] private List<ShopOnMap> _shops = new List<ShopOnMap>();

        protected override void Awake()
        {
            base.Awake();

            var findShops = GameObject.FindObjectsOfType<ShopOnMap>();
            foreach (var shop in findShops)
            {
                _shops.Add(shop);
            }

            if (Toolbox.Get<ControllerInput>() != null)
            {
                Debug.Log("OK");    
            }// .OnMouseButtonUp.AddListener(_OnMouseButtonUp);
        }

        private void _OnMouseButtonUp (ControllerInput input)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }

        public override void Tick()
        {
            base.Tick();
        }
    }
}
