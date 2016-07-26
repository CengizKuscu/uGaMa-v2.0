using System.Collections.Generic;
using UnityEngine;

namespace uGaMa.Extensions.Factory
{
    public class ObjectFactory : MonoBehaviour
    {
        public Dictionary<object, Object> factorItems;

        public ObjectFactory()
        {
            factorItems = new Dictionary<object, Object>();
        }

        public void AddItemToFactory(string path)
        {
            if (!factorItems.ContainsKey(path))
            {
                Object obj = Resources.Load(path);
                factorItems.Add(path, obj);
            }
        }

        public void AddItemToFactory(object key, GameObject obj)
        {
            if (!factorItems.ContainsKey(key))
            {
                factorItems.Add(key, obj);
            }
        }

        public void RemoveItemFromFactory(string key)
        {
            if (!factorItems.ContainsKey(key))
            {
                factorItems.Remove(key);
            }
        }

        public T GetItem<T>(object key, bool autoInstantiate = true) where T : Object
        {
            if (factorItems.ContainsKey(key))
            {
                Object obj = factorItems[key] as Object;
                T result;
                if (autoInstantiate)
                {
                    GameObject tmp = Instantiate(obj) as GameObject;
                    result = tmp as T;
                }
                else
                {
                    result = obj as T;
                }
                return result;
            }
            Debug.LogError("<color=red><b>Factory: NOT FIND ITEM</b></color>");
            return null;
        }
    }
}
