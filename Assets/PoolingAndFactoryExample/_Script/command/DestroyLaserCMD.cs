using uGaMa.Command;
using UnityEngine;

namespace PoolingAndFactoryExample
{
    public class DestroyLaserCMD : Command
    {

        public override void Execute(NotifyParam notify)
        {
            Collider2D collision = notify.Data as Collider2D;
            
            LaserView laserView = collision.gameObject.GetComponent<LaserView>();

            if (laserView)
            {
                laserView.gameObject.SetActive(false);
            }
        }
    }
}