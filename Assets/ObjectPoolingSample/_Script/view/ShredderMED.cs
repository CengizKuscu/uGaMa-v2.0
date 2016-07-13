using UnityEngine;
using uGaMa.Mediator;

namespace ObjectPoolingSample
{
    public class ShredderMED : Mediator
    {

        public override void Init()
        {

        }

        // Use this for initialization
        public override void OnRegister()
        {

        }

        // Update is called once per frame
        public override void OnRemove()
        {

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            dispatcher.Dispatch(ObjectPoolingEvents.DESTROY_LASER, collision);
        }
    }
}