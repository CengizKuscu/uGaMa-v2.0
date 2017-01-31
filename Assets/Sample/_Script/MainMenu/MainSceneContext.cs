using uGaMa.Context;
using UnityEngine;

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

            CommandMap.Bind(MainMenuEvents.START_GAME).To<StartGameCMD>();

            CommandMap.Bind(MainMenuEvents.QUIT_GAME).To<QuitGameCMD>();

            CommandMap.Bind(MainMenuEvents.LOAD_MAIN_MENU).To<LoadMainMenuCMD>();

            CommandMap.Bind(GameEvents.CREATE_TOUCH_ORDER).To<CreateTouchOrderCMD>();

            ModelMap.Bind<IMyGameModel>().To<MyGameModel>();

            MediatorMap.Bind<MainMenuView>().To<MainMenuMED>();
        }

        public override void UnBindings()
        {

        }
    }
}