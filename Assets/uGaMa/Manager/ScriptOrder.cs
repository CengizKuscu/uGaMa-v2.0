using System;
using UnityEngine;

namespace uGaMa.Manager
{
    public class ScriptOrder : Attribute
    {
        [HideInInspector]
        public int order;

        [HideInInspector]
        public static int reserveOrder = -990;

        public ScriptOrder(int order)
        {
            this.order = order;
            ScriptOrder.reserveOrder = this.order;
            //Debug.Log("+ ScriptOrder.reserveOrder: " + ScriptOrder.reserveOrder + " || " + this.order);
        }

        public ScriptOrder()
        {
            ScriptOrder.reserveOrder += 10;
            this.order = ScriptOrder.reserveOrder;
            //Debug.Log("ScriptOrder.reserveOrder: " + ScriptOrder.reserveOrder + " || " + this.order);
        }
    }
}
