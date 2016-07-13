using UnityEngine;
using uGaMa.Mediate;
using uGaMa.Command;

namespace Sample
{
    public class TurnMessageMED : Mediator
    {
        private TurnMessageView _viewComp;

        //private Text turnMessageTxt;

        private GameObject _panel;



        public override void OnRegister()
        {
            base.OnRegister();
            _viewComp = GetView() as TurnMessageView;
            _panel = GameObject.Find("Panel");

            _viewComp.turnMessageTxt.enabled = false;
            _panel.SetActive(false);
            AddListener(GameEvents.SHOW_TURN_MESSAGE, ShowTurnMessage);
            AddListener(GameEvents.HIDE_TURN_MESSAGE, HideTurnMessage);
            AddListener(GameEvents.UPDATE_LIFE, UpdateLife);
            //
        }



        private void UpdateLife(NotifyParam obj)
        {
            MyGameModel gameModel = uManager.GetModel<IMyGameModel>() as MyGameModel;
            _viewComp.lifeTxt.text = gameModel.Life.ToString();
        }

        private void HideTurnMessage(NotifyParam obj)
        {
            //_viewComp.enabled = false;
            _viewComp.turnMessageTxt.enabled = false;
            _panel.SetActive(false);
        }

        private void ShowTurnMessage(NotifyParam obj)
        {
            TurnMessageParam param = obj.data as TurnMessageParam;
            _viewComp.turnMessageTxt.text = param.message;
            _viewComp.turnMessageTxt.enabled = true;
            //_viewComp.enabled = true;
            _panel.SetActive(true);
        }

        public void Start()
        {
            dispatcher.Dispatch(GameEvents.UPDATE_LIFE);
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }


    }
}