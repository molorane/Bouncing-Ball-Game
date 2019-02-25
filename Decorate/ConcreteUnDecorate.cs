using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall.Decorate
{
    class ConcreteUnDecorate:unitDecorator
    {
        public ConcreteUnDecorate(Unit u): base(u)
        {
            base.Width -= 10;
            base.Height -= 10;
        }
    }
}
