using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    class Block:Unit,Behaviour,Observer
    {
        private int collissionsWithballs;

        private SolidBrush filling;
        private Pen drawing;

        Subject blockObservers;

        public Block(string b_name,string b_id,int b_height,int b_width,int xPos,int yPos,int xv,int yv,Subject blockObserver)
        {
            this.Name = b_name;
            this.Id = b_id;
            this.Height = b_height;
            this.Width = b_width;

            this.curXPos = xPos;
            this.curYPos = yPos;

            this.xV = xv;
            this.yV = yv;

            this.filling = new SolidBrush(Color.Black);
            this.drawing = new Pen(Color.White, 0);

            this.unitShape = new Rectangle(
                   this.curXPos,
                   this.curYPos,
                   this.Width,
                   this.Height);

            this.collissionsWithballs = 0;

            this.blockObservers = blockObserver;

            blockObservers.registerObserver(this);
        }


        public void update(int xV, int yV)
        {
            this.xV = 0;
            this.yV = 0;
        }

        public override Rectangle draw()
        {
            return this.unitShape;
        }

        public Rectangle getBlock()
        {
            return this.unitShape;
        }

        public void setBehaviour(SolidBrush fill, Pen draw)
        {
            this.filling = fill;
            this.drawing = draw;
        }

        public void setFillBehaviour(SolidBrush fill)
        {
            this.filling = fill;
        }

        public SolidBrush getFilling()
        {
            return this.filling;
        }

        public Pen getDrawing()
        {
            return this.drawing;
        }

        public void CollisionDetected()
        {
            this.collissionsWithballs++;
        }

        public int collisions()
        {
            return collissionsWithballs;
        }

    }
}
