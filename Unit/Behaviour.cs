﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    interface Behaviour
    {
        void setBehaviour(SolidBrush fill, Pen draw);
        SolidBrush getFilling();
        Pen getDrawing();
    }
}
