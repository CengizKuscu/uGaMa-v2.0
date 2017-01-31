using System;
using System.Collections.Generic;
using uGaMa.Manager;
using UnityEngine;

namespace uGaMa.Mediate
{
    public class View : MonoBehaviour, IView
    {
        private Mediator _mediate;

        private BaseGameManager _gameManager;

        internal void RemoveMED(object key)
        {
            if (key != null)
            {
                Destroy(GetComponent(key.GetType()));
            }
        }

        public void Awake()
        {
            MapView();
        }

        private void MapView()
        {
            _gameManager = BaseGameManager.GetInstance();

            object key = this.GetType();

            var binding = _gameManager.mediatorMap.GetBind(key);
            var binded = binding.Binded;

            foreach (var bindedPair in binded)
            {
                var mediateType = bindedPair.Value as Type;

                foreach (var o in FindObjectsOfType((Type) key))
                {
                    var item = (View) o;
                    if (item != this) continue;
                    var view = item;

                    view.gameObject.AddComponent(mediateType);

                    _mediate = view.GetComponent(mediateType) as Mediator;
                    if (_mediate == null) continue;
                    _mediate.SetView(view);

                    Dictionary<object, IMediator> mediated;
                    if (!_gameManager.mediatorMap.mediators.ContainsKey(key))
                    {
                        mediated = new Dictionary<object, IMediator> {{this, _mediate}};
                        _gameManager.mediatorMap.mediators.Add(key, mediated);
                    }
                    else
                    {
                        mediated = _gameManager.mediatorMap.mediators[key];
                        if (!mediated.ContainsKey(this))
                        {
                            mediated.Add(this, _mediate);
                        }
                    }
                    _mediate.OnRegister();
                }
            }
        }

        public void OnDestroy()
        {
            _mediate.RemoveAllListeners();

            _gameManager.mediatorMap.RemoveMED(this.GetType(), this);

            OnRemove();
        }

        public virtual void OnRemove() { }
    }
}
