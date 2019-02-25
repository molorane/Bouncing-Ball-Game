using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall.Factory
{
    public abstract class UnitStore
    {
        public Unit createUnit(string type, string name, string id, int width, int height, int xPos, int yPos, int xv, int yv, UnitsObservers ub)
        {
            return CreateUnit(type,name,id,width,height,xPos,yPos,xv,yv,ub);
        }

        public abstract Unit CreateUnit(string type, string name, string id, int width, int height, int xPos, int yPos, int xv, int yv, UnitsObservers ub);
    }
}
