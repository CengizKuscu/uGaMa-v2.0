using UnityEngine;

namespace uGaMa.Utils
{
    static class MonoBehaviourUtils
    {
        /// <summary>
        /// Gets or add a component. Usage example:
        /// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>(gameobject);
        /// </summary>
        static public T GetOrAddComponent<T>(GameObject child) where T : Component
        {
            T result = child.GetComponent<T>();
            if (result == null)
            {
                result = child.AddComponent<T>();
            }
            return result;
        }


        /// <summary>
        /// Remove a component. Usage example:
        /// transform.RemoveComponent<BoxCollider>(gameobject);
        /// </summary>
        internal static void RemoveComponent<T>(GameObject gameObject) where T : Component
        {
            T result = gameObject.GetComponent<T>();
            if(result != null)
            {
                GameObject.Destroy(result);
            }
        }
    }
}
