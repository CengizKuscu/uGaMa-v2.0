using UnityEngine;
using uGaMa.Context;

namespace Sample
{
    public class MainSceneContext : Context
    {

        public override void Init()
        {
            base.Init();
            Debug.Log("MainSceneContext Init");
        }

        public override void Bindings()
        {
            base.Bindings();


            Debug.Log("MainSceneContext Bindings");

            commandMap.Bind(MainMenuEvents.START_GAME).To<StartGameCMD>();

            commandMap.Bind(MainMenuEvents.QUIT_GAME).To<QuitGameCMD>();

            commandMap.Bind(MainMenuEvents.LOAD_MAIN_MENU).To<LoadMainMenuCMD>();

            commandMap.Bind(GameEvents.CREATE_TOUCH_ORDER).To<CreateTouchOrderCMD>();

            modelMap.Bind<IMyGameModel>().To<MyGameModel>();

            mediatorMap.Bind<MainMenuView>().To<MainMenuMED>();
        }

        public override void UnBindings()
        {

        }
    }
}