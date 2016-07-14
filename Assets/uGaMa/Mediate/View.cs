using System;
using System.Collections.Generic;
using uGaMa.Bind;
using uGaMa.Manager;
using UnityEngine;

namespace uGaMa.Mediate
{
    public class View : MonoBehaviour, IView
    {

        private Mediator mediate;

        private BaseGameManager gameManager;

        internal void RemoveMED(object key)
        {
            if (key != null)
            {
                Destroy(GetComponent(key.GetType()));
            }
        }

        public void Awake()
        {
            mapView();
        }

        private void mapView()
        {
            gameManager = BaseGameManager.GetInstance();

            Dictionary<object, object> binded;

            object key = this.GetType();

            IBinding binding = gameManager.mediatorMap.GetBind(key);
            binded = binding.Binded;

            foreach (KeyValuePair<object, object> bindedPair in binded)
            {
                Type mediateType = bindedPair.Value as Type;
                View view;

                foreach (View item in GameObject.FindObjectsOfType(key as Type))
                {
                    if (item == this)
                    {

                        view = item;

                        view.gameObject.AddComponent(mediateType);

                        mediate = view.GetComponent(mediateType) as Mediator;
                        mediate.SetView(view);

                        Dictionary<object, IMediator> mediated;
                        if (!gameManager.mediatorMap.mediators.ContainsKey(key))
                        {
                            mediated = new Dictionary<object, IMediator>();
                            mediated.Add(this, mediate);
                            gameManager.mediatorMap.mediators.Add(key, mediated);
                        }
                        else
                        {
                            mediated = gameManager.mediatorMap.mediators[key];
                            if (!mediated.ContainsKey(this))
                            {
                                mediated.Add(this, mediate);
                            }
                        }
                        mediate.OnRegister();
                    }
                }
            }
        }

        public void OnDestroy()
        {
            mediate.RemoveAllListeners();

            gameManager.mediatorMap.RemoveMED(this.GetType(), this);

            OnRemove();
        }

        virtual public void OnRemove() { }
    }
}
