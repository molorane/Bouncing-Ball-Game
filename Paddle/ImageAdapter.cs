using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    public class ImageAdapter:IGraphic
    {
        private Image image;

        public ImageAdapter(Image image)
        {
            this.image = image;
        }

        public Bitmap GetBitmap()
        {
            return image.RetrieveImage();
        }
    }
}
