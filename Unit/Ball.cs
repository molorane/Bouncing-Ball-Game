using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncingBall
{
    public class Ball:Unit,Behaviour,Observer
    {
        SolidBrush filling;
        Pen drawing;

        Subject ballObservers;

        public Ball(string b_name, string b_id, int b_height, int b_width, int xPos, int yPos, int xv, int yv, Subject ballObserver)
        {
            this.Name = b_name;
            this.Id = b_id;

            this.Width = b_width;
            this.Height = b_height;

            this.curXPos = xPos;
            this.curYPos = yPos;

            this.xV = xv;
            this.yV = yv;

            this.filling = new SolidBrush(Color.Red);
            this.drawing = new Pen(Color.Black,0);

            this.unitShape = new Rectangle(
                   this.curXPos,
                   this.curYPos,
                   this.Width,
                   this.Height);

            ballObservers = ballObserver;

            ballObservers.registerObserver(this);
        }

        public void update(int xv, int yv)
        {
            this.xV = xv;
            this.yV = yv;
        }

        public override Rectangle draw()
        {
            return unitShape;
        }

        //Mutator methods
        public void setBallWidth(int w)
        {
            this.Width += 10;
        }

        public void undecorate()
        {
            this.Width -= 10;
            this.Height -= 10;
        }

        public void decorate()
        {
            this.Width += 10;
            this.Height += 10;
        }

        public void setBallHeight(int h)
        {
            this.Height += 10;
        }

        public void setBallSize(int width,int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void setXVelocity(int v)
        {
            this.xV = v;
        }

        public void setYVelocity(int v)
        {
            this.yV = v;
        }

        public void setVelocity(int xVelocity,int yVelocity)
        {
            this.xV = xVelocity;
            this.yV = yVelocity;

        }

        public void updateShape()
        {
            this.unitShape = new Rectangle(
                   this.curXPos,
                   this.curYPos,
                   this.Width,
                   this.Height);
        }

        public void updateXpos()
        {
            this.unitShape.X += this.xV;
            this.curXPos += this.xV;

            updateShape();
        }

        public void updateYpos()
        {
            this.unitShape.Y += this.yV;
            this.curYPos += this.yV;

            updateShape();
        }

        public void updatexVelocity()
        {
            this.xV = -xV;

            updateShape();
        }

        public void updateyVelocity()
        {
            this.yV = -yV;

            updateShape();
        }

        //Accessor methods

        public string getName()
        {
            return this.Name;
        }

        public string getID()
        {
            return this.Id;
        }

        public int getXVelocity()
        {
            return this.xV;
        }

        public int getYVelocity()
        {
            return this.yV;
        }

        public int getcurXPos()
        {
            return curXPos;
        }

        public int getcurYPos()
        {
            return curYPos;
        }

        public int getBallWidth()
        {
            return this.unitShape.Width;
        }

        public int getBallHeight()
        {
            return this.unitShape.Height;
        }

        public Rectangle getBall()
        {
            return unitShape;
        }


        public void setBehaviour(SolidBrush fill, Pen draw)
        {
            this.filling = fill;
            this.drawing = draw;
        }

        public SolidBrush getFilling()
        {
            return this.filling;
        }

        public Pen getDrawing()
        {
            return this.drawing;
        }
    }
}
