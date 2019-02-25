using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    public class Image
    {
        public Bitmap RetrieveImage()
        {
            System.Drawing.Bitmap bitmap = BouncingBall.Properties.Resources.Paddle;
            return bitmap;
        }
    }
}
