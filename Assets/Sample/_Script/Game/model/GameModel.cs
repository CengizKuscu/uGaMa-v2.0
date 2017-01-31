using System;
using System.Collections.Generic;

namespace Sample
{
    public class MyGameModel : IMyGameModel
    {
        private List<int> touchOrder;
        private int life = 3;

        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
            }
        }

        public List<int> TouchOrder
        {
            get
            {
                return touchOrder;
            }

            set
            {
                touchOrder = value;
            }
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}