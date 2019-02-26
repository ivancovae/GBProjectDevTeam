using UnityEngine;
using UnityEngine.EventSystems;

namespace Games
{
    // Поведение магазина на карте
    public class ShopOnMap : BaseObjectScene, IPointerDownHandler, IPointerUpHandler
    {

#region Serialize Variable
        [SerializeField] private Sprite selected;
#endregion

#region Protected Variable
        private Sprite _default;
#endregion

#region Abstract Function
        protected override void Awake()
        {
            base.Awake();
            _default = _renderer.sprite;
        }
#endregion

        public void SelectShop()
        {
            if (selected != null)
                _renderer.sprite = selected;
        }

        public void DeselectShop()
        {
            _renderer.sprite = _default;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Main.Instance.ShopsController.DeselectShop();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Main.Instance.ShopsController.SelectShop(this);
        }
    }
}