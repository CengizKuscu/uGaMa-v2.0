using uGaMa.Context;
using uGaMa.Extensions.Factory;
using uGaMa.Utils;
using UnityEngine;

namespace PoolingAndFactoryExample
{
    public class ObjectPoolingContext : Context
    {

        public override void Bindings()
        {
            MediatorMap.Bind<SpaceShipView>().To<SpaceShipMED>();
            MediatorMap.Bind<LaserView>().To<LaserMED>();
            MediatorMap.Bind<ShredderView>().To<ShredderMED>();
            MediatorMap.Bind<FormationView>().To<FormationMED>();

            ObjectFactory factory = uManager.GetOrAddExtension<ObjectFactory>();
            factory.AddItemToFactory(FactoryItems.SPACESHIP);

            
            LaserPooler laserPooler = uManager.GetOrAddExtension<LaserPooler>();
            laserPooler.TargetParent = transform;
            laserPooler.PooledAmount = 21;
            laserPooler.PooledObject = Resources.Load("Prefabs/Laser") as GameObject;
            laserPooler.WillGrow = false;

            SpaceShipPooler spaceShipPooler = uManager.GetOrAddExtension<SpaceShipPooler>();
            spaceShipPooler.TargetParent = transform;
            spaceShipPooler.PooledAmount = 2;
            spaceShipPooler.WillGrow = false;
            spaceShipPooler.PooledObject = Resources.Load("Prefabs/SpaceShip") as GameObject;

            CommandMap.Bind(ObjectPoolingEvents.DESTROY_LASER).To<DestroyLaserCMD>();
        }


        public override void UnBindings()
        {
            MonoBehaviourUtils.RemoveComponent<LaserPooler>(gameObject);
        }
    }
}