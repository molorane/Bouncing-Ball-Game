using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    public interface Subject
    {
        void registerObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObserver();
    }
}
