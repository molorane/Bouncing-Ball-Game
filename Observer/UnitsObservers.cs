using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    public class UnitsObservers:Subject
    {
        private ArrayList observers;
        private int xV;
        private int yV;

        public UnitsObservers()
        {
            observers = new ArrayList();
        }

        public void registerObserver(Observer observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void removeObserver(Observer observer)
        {
            int index = observers.IndexOf(observer);

            if (index >= 0)
            {
                observers.Remove(observer);
            }
        }

        public void notifyObserver()
        {
            foreach (Observer obs in observers)
            {
                obs.update(xV, yV);
            }
        }

        public void setVelocity(int xv, int yv)
        {
            this.xV = xv;
            this.yV = yv;
            notifyObserver();
        }

        public ArrayList getObservers()
        {
            return this.observers;
        }
    }
}
