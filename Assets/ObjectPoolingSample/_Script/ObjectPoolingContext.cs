using uGaMa.Context;
using uGaMa.Utils;
using UnityEngine;

namespace ObjectPoolingSample
{
    public class ObjectPoolingContext : Context
    {

        public override void Bindings()
        {
            mediatorMap.Bind<SpaceShipView>().To<SpaceShipMED>();
            mediatorMap.Bind<LaserView>().To<LaserMED>();
            mediatorMap.Bind<ShredderView>().To<ShredderMED>();
            mediatorMap.Bind<FormationView>().To<FormationMED>();
            
            LaserPooler laserPooler = uManager.GetOrAddExtension<LaserPooler>();
            laserPooler.TargetParent = transform;
            laserPooler.PooledAmount = 5;
            laserPooler.PooledObject = Resources.Load("Prefabs/Laser") as GameObject;
            laserPooler.WillGrow = false;

            SpaceShipPooler spaceShipPooler = uManager.GetOrAddExtension<SpaceShipPooler>();
            spaceShipPooler.TargetParent = transform;
            spaceShipPooler.PooledAmount = 2;
            spaceShipPooler.WillGrow = false;
            spaceShipPooler.PooledObject = Resources.Load("Prefabs/SpaceShip") as GameObject;

            commandMap.Bind(ObjectPoolingEvents.DESTROY_LASER).To<DestroyLaserCMD>();
        }


        public override void UnBindings()
        {
            MonoBehaviourUtils.RemoveComponent<LaserPooler>(gameObject);
        }
    }
}