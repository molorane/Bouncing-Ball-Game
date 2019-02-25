using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    public sealed class Paddle:System.Windows.Forms.PictureBox
    {
        private volatile static Paddle uniqueInstance;

        private static readonly object syncRoot = new object();

        private Paddle() { }

        public static Paddle getInstance()
        {
            if (uniqueInstance == null)
            {
                // Put a lock on syncRoot. 
                // This locks it to make the object thread safe.
                lock (syncRoot)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Paddle();
                    }
                }
            }
            return uniqueInstance;
        }
    }
}
