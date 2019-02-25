using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    public interface Observer
    {
        void update(int xV, int yV);
    }
}
