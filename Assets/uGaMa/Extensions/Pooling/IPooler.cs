using System.Collections.Generic;
using UnityEngine;

namespace uGaMa.Extensions.Pooling
{
    public interface IPooler
    {
        int PooledAmount { get; set; }
        List<GameObject> PooledObjects { get; }
        GameObject PooledObject { get; set; }
        bool WillGrow { get; set; }
        GameObject GetPooledObject();
        Transform TargetParent { get; set; } 
    }
}
