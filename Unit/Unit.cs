using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    public abstract class Unit:Observer
    {
           protected string Name;
           protected string Id;
           protected int Height, Width, //Unit Size
                         curXPos, curYPos; //coordinates of position

           protected Rectangle unitShape;
           protected int xV,yV; //Velocity

           public virtual Rectangle draw()
           {
               return unitShape;
           }

            public void update(int xv, int yv)
            {
                this.xV = xv;
                this.yV = yv;
            }
    }
}
