using uGaMa.Extensions.Factory;
using uGaMa.Mediate;
using UnityEngine;

namespace PoolingAndFactoryExample
{
    public class FormationMED : Mediator
    {
        SpaceShipPooler spaceShipPooler;
        ObjectFactory factory;

        public override void Init()
        {

        }

        // Use this for initialization
        public override void OnRegister()
        {
            spaceShipPooler = uManager.GetOrAddExtension<SpaceShipPooler>();
            factory = uManager.GetOrAddExtension<ObjectFactory>();
        }

        // Update is called once per frame
        public override void OnRemove()
        {

        }

        public void Start()
        {
            Vector3 offSet;

            #region Object Pooling
            GameObject obj = spaceShipPooler.GetPooledObject();
            if (obj == null)
            {
                return;
            }
            obj.SetActive(true);
            offSet = new Vector3(-4, 1, 0);
            obj.transform.position = transform.position + offSet;
            obj.transform.rotation = Quaternion.identity;

            obj = spaceShipPooler.GetPooledObject();
            if (obj == null)
            {
                return;
            }
            obj.SetActive(true);
            offSet = new Vector3(4, 1, 0);
            obj.transform.position = transform.position + offSet;
            obj.transform.rotation = Quaternion.identity;
            #endregion

            #region Item Factory
            GameObject spaceShip = factory.GetItem<GameObject>(FactoryItems.SPACESHIP);
            offSet = new Vector3(0, 1, 0);
            spaceShip.transform.parent = transform;
            spaceShip.transform.position = transform.position + offSet;
            spaceShip.transform.rotation = Quaternion.identity;
            #endregion
        }
    }
}