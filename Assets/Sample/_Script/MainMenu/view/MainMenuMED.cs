using uGaMa.Mediate;
using UnityEngine;
using UnityEngine.UI;

namespace Sample
{
    public class MainMenuMED : Mediator
    {
        private MainMenuView _viewComp;

        //private Button _playBtn;

        //private Button _quitBtn;

        public override void OnRegister()
        {
            Debug.Log("OnRegister: " + this);
            _viewComp = GetView() as MainMenuView;
            _viewComp.playBtn.GetComponent<Button>().onClick.AddListener(PlayBtnOnClick);

            _viewComp.quitBtn.GetComponent<Button>().onClick.AddListener(QuitBtnOnClick);
        }

        private void QuitBtnOnClick()
        {
            Debug.Log("QuitBtnOnClick CLICK");
            dispatcher.Dispatch(MainMenuEvents.QUIT_GAME);
        }

        public void PlayBtnOnClick()
        {
            Debug.Log("PLAY CLICK");
            dispatcher.Dispatch(MainMenuEvents.START_GAME, "Game_0");
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }

        public override void Init()
        {
            base.Init();
            //uManager.SendNotify(MainMenuEvents.START_GAME, "Game_0");
        }


    }
}