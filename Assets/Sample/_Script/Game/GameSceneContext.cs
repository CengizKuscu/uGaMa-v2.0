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
            commandMap.Bind(GameEvents.CREATE_TOUCH_ORDER).To<CreateTouchOrderCMD>();

            commandMap.Bind(MainMenuEvents.LOAD_MAIN_MENU).To<LoadMainMenuCMD>();

            mediatorMap.Bind<GameView>().To<GameMED>();

            mediatorMap.Bind<GameItem>().To<GameItemMED>();

            mediatorMap.Bind<TurnMessageView>().To<TurnMessageMED>();

            modelMap.Bind<IMyGameModel>().To<MyGameModel>();
        }

        public override void UnBindings()
        {

        }

    }
}