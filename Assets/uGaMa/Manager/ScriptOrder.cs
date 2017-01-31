using System;
using UnityEngine;

namespace uGaMa.Manager
{
    public class ScriptOrder : Attribute
    {
        [HideInInspector]
        public int Order;

        [HideInInspector]
        public static int ReserveOrder = -9999;

        public ScriptOrder(int order)
        {
            this.Order = order;
            ReserveOrder = this.Order;
            //Debug.Log("+ ScriptOrder.reserveOrder: " + ScriptOrder.reserveOrder + " || " + this.order);
        }

        public ScriptOrder()
        {
            ReserveOrder += 1;
            this.Order = ReserveOrder;
            //Debug.Log("ScriptOrder.reserveOrder: " + ScriptOrder.reserveOrder + " || " + this.order);
        }
    }
}
