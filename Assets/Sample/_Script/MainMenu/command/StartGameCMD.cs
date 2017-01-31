using uGaMa.Command;
using UnityEngine.SceneManagement;

namespace Sample
{
    public class StartGameCMD : Command
    {
        public override void Execute(NotifyParam notify)
        {
            MyGameModel gameModel = uManager.GetModel<IMyGameModel>() as MyGameModel;

            string sceneName = notify.Data as string;



            gameModel.Life = 1;

            SceneManager.LoadScene(sceneName);
        }
    }
}