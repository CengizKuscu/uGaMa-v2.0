using UnityEngine;
using uGaMa.Extensions.Pooling;
using uGaMa.Mediate;

namespace ObjectPoolingSample
{
    public class SpaceShipMED : Mediator
    {

        LaserPooler laserPooler;

        public override void Init()
        {

        }

        // Use this for initialization
        public override void OnRegister()
        {
            laserPooler = uManager.GetOrAddExtension<LaserPooler>();
        }

        // Update is called once per frame
        public override void OnRemove()
        {

        }

        public void Start()
        {
            //InvokeRepeating("Fire", 0.05f, 0.05f);
        }

        private void Fire()
        {
            GameObject obj = laserPooler.GetPooledObject();
            if (obj == null)
            {
                return;
            }
            obj.SetActive(true);
            Vector3 offSet = new Vector3(0, 1, 0);
            obj.transform.position = transform.position + offSet;
            obj.transform.rotation = Quaternion.identity;
            Rigidbody2D rigid = obj.GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector2(0, 5);


        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating("Fire", 0.000001f, 0.2f);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke("Fire");
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {

        }
    }
}