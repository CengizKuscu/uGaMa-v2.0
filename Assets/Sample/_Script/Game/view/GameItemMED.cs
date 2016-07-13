using uGaMa.Command;
using uGaMa.Mediate;
using UnityEngine;

namespace Sample
{
    public class GameItemMED : Mediator
    {
        private GameItem _view;

        Collider2D coll;

        public override void OnRegister()
        {
            base.OnRegister();
            _view = GetView() as GameItem;
            coll = _view.gameObject.GetComponent<Collider2D>();
            AddListener(GameEvents.SHOW_TOUCH, ShowTouch);
            AddListener(GameEvents.HIDE_TOUCH, HideTouch);
            AddListener(GameEvents.CREATE_TOUCH_ORDER, CreateTouchOrderHandler);
            AddListener(GameEvents.ITEM_ACTIVE, ItemActive);
        }

        private void ItemActive(NotifyParam obj)
        {
            Debug.Log("COLLIDER ACTIVE");
            coll.enabled = true;
        }

        private void CreateTouchOrderHandler(NotifyParam obj)
        {
            Debug.Log("COLLIDER DEACTIVE");
            coll.enabled = false;
        }

        private void HideTouch(NotifyParam obj)
        {

            int showIndex = (int)obj.data;
            //Debug.Log("HideTouch: " + showIndex.ToString() + " || " + _view.itemIndex.ToString());
            if (showIndex == _view.itemIndex)
            {
                LoadSprite(0);
            }
        }

        private void ShowTouch(NotifyParam obj)
        {
            int showIndex = (int)obj.data;
            //Debug.Log("HideTouch: " + showIndex.ToString() + " || " + _view.itemIndex.ToString());
            if (showIndex == _view.itemIndex)
            {
                LoadSprite(1);
            }
        }

        private void LoadSprite(int spriteIndex)
        {
            if (_view.viewSprite[spriteIndex] != null)
            {
                GetComponent<SpriteRenderer>().sprite = _view.viewSprite[spriteIndex];
            }
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }

        public void Update()
        {

        }

        public void OnMouseDown()
        {
            Debug.Log("CLICKED");
            dispatcher.Dispatch(GameEvents.TOUCH, _view.itemIndex);
            LoadSprite(1);
        }

        public void OnMouseUp()
        {
            LoadSprite(0);
        }
    }
}