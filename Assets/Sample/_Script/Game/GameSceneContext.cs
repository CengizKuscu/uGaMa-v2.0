using uGaMa.Context;
using UnityEngine;

namespace Sample
{
    public class GameSceneContext : Context
    {

        public override void Init()
        {
            base.Init();
            Debug.Log("GameSceneContext Init");
        }

        public override void Bindings()
        {
            CommandMap.Bind(GameEvents.CREATE_TOUCH_ORDER).To<CreateTouchOrderCMD>();

            CommandMap.Bind(MainMenuEvents.LOAD_MAIN_MENU).To<LoadMainMenuCMD>();

            MediatorMap.Bind<GameView>().To<GameMED>();

            MediatorMap.Bind<GameItem>().To<GameItemMED>();

            MediatorMap.Bind<TurnMessageView>().To<TurnMessageMED>();

            ModelMap.Bind<IMyGameModel>().To<MyGameModel>();
        }

        public override void UnBindings()
        {

        }

    }
}