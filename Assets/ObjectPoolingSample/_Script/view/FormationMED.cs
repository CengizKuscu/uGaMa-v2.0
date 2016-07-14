using UnityEngine;
using uGaMa.Mediate;

namespace ObjectPoolingSample
{
    public class FormationMED : Mediator
    {
        SpaceShipPooler spaceShipPooler;

        public override void Init()
        {

        }

        // Use this for initialization
        public override void OnRegister()
        {
            spaceShipPooler = uManager.GetOrAddExtension<SpaceShipPooler>();

        }

        // Update is called once per frame
        public override void OnRemove()
        {

        }

        public void Start()
        {
            GameObject obj = spaceShipPooler.GetPooledObject();
            if (obj == null)
            {
                return;
            }
            obj.SetActive(true);
            Vector3 offSet = new Vector3(-4, 1, 0);
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

        }
    }
}