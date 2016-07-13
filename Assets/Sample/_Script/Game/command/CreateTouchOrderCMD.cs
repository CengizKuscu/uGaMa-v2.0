using UnityEngine;
using uGaMa.Command;
using System.Collections.Generic;

namespace Sample
{
    public class CreateTouchOrderCMD : Command
    {
        public override void Execute(NotifyParam notify)
        {
            MyGameModel gameModel = uManager.GetModel<IMyGameModel>() as MyGameModel;

            gameModel.TouchOrder = new List<int>();

            int random = Random.Range(1, 3);
            gameModel.TouchOrder.Add(random);
            Debug.Log("Random: " + random);

            random = Random.Range(1, 3);
            gameModel.TouchOrder.Add(random);
            Debug.Log("Random: " + random);

            random = Random.Range(1, 3);
            gameModel.TouchOrder.Add(random);
            Debug.Log("Random: " + random);
        }
    }
}