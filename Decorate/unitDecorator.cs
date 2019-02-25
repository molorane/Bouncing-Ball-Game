using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall.Decorate
{
    class unitDecorator:Unit
    {
         protected Unit unit { get; set; }

         public unitDecorator(Unit u)
         {
            unit = u;
         }
    }
}
