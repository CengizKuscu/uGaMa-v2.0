using uGaMa.Command;
using UnityEngine;

namespace Sample
{
    public class QuitGameCMD : Command
    {
        public override void Execute(NotifyParam notify)
        {
            Application.Quit();
        }
    }
}