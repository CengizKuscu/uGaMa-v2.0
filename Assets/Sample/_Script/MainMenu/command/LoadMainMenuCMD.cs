using uGaMa.Command;
using UnityEngine.SceneManagement;

namespace Sample
{
    public class LoadMainMenuCMD : Command
    {
        public override void Execute(NotifyParam notify)
        {

            SceneManager.LoadScene("MainMenu");
        }
    }
}