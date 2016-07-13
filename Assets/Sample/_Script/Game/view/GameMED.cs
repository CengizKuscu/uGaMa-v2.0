using System.Collections;
using System.Collections.Generic;
using uGaMa.Command;
using uGaMa.Mediator;
using UnityEngine;

namespace Sample
{
    public class GameMED : Mediator
    {
        public List<int> clientTouchOrder;

        MyGameModel gameModel;

        public override void OnRegister()
        {
            base.OnRegister();
            gameModel = uManager.GetModel<IMyGameModel>() as MyGameModel;
            clientTouchOrder = new List<int>();
            //AddListener(GameEvents.TOUCH, TouchHandler);
            AddListener(GameEvents.CHECK_TOUCH_ORDER, CheckTouchOrder);
            AddListener(GameEvents.CREATE_TOUCH_ORDER, CreatedTouchOrder);
            AddListener(GameEvents.SHOW_TURN_MESSAGE, ShowTurnMessage);
            AddListener(GameEvents.HIDE_TURN_MESSAGE, HideTurnMessage);

        }

        private void ShowTurnMessage(NotifyParam obj)
        {
            StartCoroutine(StartTurn());
        }

        private IEnumerator StartTurn()
        {
            yield return new WaitForSeconds(3);
            dispatcher.Dispatch(GameEvents.HIDE_TURN_MESSAGE);
            if (gameModel.Life > 0)
            {
                dispatcher.Dispatch(GameEvents.CREATE_TOUCH_ORDER);
            }
            else
            {
                dispatcher.Dispatch(MainMenuEvents.LOAD_MAIN_MENU);
            }
        }

        private void HideTurnMessage(NotifyParam obj)
        {
            dispatcher.Dispatch(GameEvents.UPDATE_LIFE);

            Debug.Log("HIDE TURN MESSAGE " + gameModel.Life);
        }

        private void CreatedTouchOrder(NotifyParam obj)
        {

            StartCoroutine(ShowTouchOrder());
        }

        IEnumerator ShowTouchOrder()
        {
            int touchOrderCount = gameModel.TouchOrder.Count;

            for (int i = 0; i < touchOrderCount; i++)
            {
                int val = gameModel.TouchOrder[i];
                if (i != 0)
                {

                    yield return new WaitForSeconds(0.5f);
                    dispatcher.Dispatch(GameEvents.HIDE_TOUCH, gameModel.TouchOrder[i - 1]);
                }

                yield return new WaitForSeconds(1);
                dispatcher.Dispatch(GameEvents.SHOW_TOUCH, val);
            }

            yield return new WaitForSeconds(1);
            dispatcher.Dispatch(GameEvents.HIDE_TOUCH, gameModel.TouchOrder[gameModel.TouchOrder.Count - 1]);
            AddListener(GameEvents.TOUCH, TouchHandler);
            dispatcher.Dispatch(GameEvents.ITEM_ACTIVE);
            yield break;
        }

        public void Start()
        {
            dispatcher.Dispatch(GameEvents.CREATE_TOUCH_ORDER);
        }

        private void CheckTouchOrder(NotifyParam obj)
        {
            List<int> touchOrder = gameModel.TouchOrder;

            bool check = true;

            for (int i = 0; i < touchOrder.Count; i++)
            {
                if (touchOrder[i] != clientTouchOrder[i])
                {
                    check = false;
                    break;
                }
            }

            clientTouchOrder = new List<int>();

            TurnMessageParam turnMessageParam = new TurnMessageParam();
            turnMessageParam.isCorrect = check;
            if (check)
            {
                turnMessageParam.message = "WELL DONE!!!";
            }
            else
            {
                gameModel.Life--;
                turnMessageParam.message = "SORRY!!!";
            }

            dispatcher.Dispatch(GameEvents.SHOW_TURN_MESSAGE, turnMessageParam);
        }

        private void TouchHandler(NotifyParam obj)
        {
            int clientTouchIndex = (int)obj.data;
            List<int> touchOrder = gameModel.TouchOrder;
            clientTouchOrder.Add(clientTouchIndex);
            Debug.Log("GAME MED CLICKED");
            if (clientTouchOrder.Count == touchOrder.Count)
            {
                RemoveListener(GameEvents.TOUCH, TouchHandler);
                dispatcher.Dispatch(GameEvents.CHECK_TOUCH_ORDER);
            }

            //Debug.Log("TOUCH HANDLER: " + obj.data);
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }

        public void Update()
        {
            //uManager.SendNotify(GameEvents.TOUCH, "touch");
        }
    }
}