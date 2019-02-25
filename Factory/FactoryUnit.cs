using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall.Factory
{
    public class FactoryUnit:UnitStore
    {
        public override Unit CreateUnit(string type, string name, string id, int width, int height, int xPos, int yPos, int xv, int yv, UnitsObservers ub)
        {
            if (type == "Block")
            {
               return new Block(name, id, width, height, xPos, yPos, xv, yv, ub);
            }
            else if (type == "Ball")
            {
               return new Ball(name, id, width, height, xPos, yPos, xv, yv, ub);
            }
            return null;
        }
    }
}
