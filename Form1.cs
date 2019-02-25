using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;
using System.Drawing.Drawing2D;
using System.Collections;
using BouncingBall.Decorate;
using BouncingBall.Factory;

namespace BouncingBall
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private int currentX;

        private const int width = 50;

        private Paddle paddle;
        private IGraphic image = new ImageAdapter(new Image());
   
        private UnitsObservers unitsObservers;

        private ArrayList observers;
        private int lives = 100;

        private Unit ballToDecorate;


        private UnitStore unitFactory = new FactoryUnit();


        private bool ballsCanCollide;

        public Form1()
        {
            InitializeComponent();

            unitsObservers = new UnitsObservers();
        }



        // Initialize some random stuff.
        private void Form1_Load(object sender, EventArgs e)
        {
            paddle = Paddle.getInstance();

            ballsCanCollide = false;

            chances.Text = "Chances left "+lives;

            InitializePaddle(paddle);


            initializeBalls();

            initializeBlocks();


            observers = unitsObservers.getObservers();

            doubleBuffer();
        }

        public void doubleBuffer()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            this.UpdateStyles();
        }

        public void initializeBalls()
        {
            Random rnd = new Random();

            unitFactory.createUnit("Ball", "A1", "A1", 30, 30, 300, 200, 5, 5, unitsObservers);

            unitFactory.createUnit("Ball","B1", "B1", 30, 30, 300, 150, 8, 8, unitsObservers);

            ballToDecorate = (unitFactory.createUnit("Ball", "Ball1", "Ball1", 50, 50, 200, 200, 4, 4, unitsObservers) as Ball);
            (ballToDecorate as Ball).setBehaviour(new SolidBrush(Color.Green), Pens.Black);
        }

        public void initializeBlocks()
        {
            int colSize = balls_ground.Width / 7;
            int YPos = 30;

            for (int i = 0; i < 2; i++) 
            {
                for (int j = 1; j <= 6; j++) 
                {
                    unitFactory.createUnit("Block", "A1", "A1", 40, 40, ((colSize * j) - 40), YPos, 0, 0, unitsObservers);
                }
                YPos += 80;
            }

        }


        public void InitializePaddle(Paddle paddle)
        {
            this.balls_ground.Controls.Add(paddle);

            paddle.BackgroundImage = image.GetBitmap();
            paddle.Location = new System.Drawing.Point(168, 332);
            Name = "thePaddle";
            paddle.Size = new System.Drawing.Size(129, 29);
            paddle.TabIndex = 0;
            paddle.TabStop = false;
            paddle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paddle_MouseDown);
            paddle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paddle_MouseMove);
            paddle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paddle_MouseUp);
        }

        // Update the ball's position, bouncing if necessary.
        private void tmrMoveBall_Tick(object sender, EventArgs e)
        {
            chances.Text = "Chances left " + lives;
            blocks_left.Text = "Blocks left " + numberOfBlocks();

            if(!blocksExists())
            {
                observers.Clear();
                tmrMoveBall.Enabled = false;
                MessageBox.Show("You won the game!");
            }
            if (lives != 0)
            {
                foreach (Observer obj in observers)
                {
                    if (obj is Ball)
                    {
                        (obj as Ball).updateXpos();
                        (obj as Ball).updateYpos();

                        ballCollisionWithPaddle(obj);

                        if ((obj as Ball).getBall().X < 0)
                        {
                            (obj as Ball).updatexVelocity();
                            collisions.Items.Add("Ball Collided wall left.");
                        }

                        else if ((obj as Ball).getcurXPos() + (obj as Ball).getBallWidth() > balls_ground.Width)
                        {
                            (obj as Ball).updatexVelocity();
                            collisions.Items.Add("Ball Collided wall right.");
                        }



                        if ((obj as Ball).getBall().Y < 0)
                        {
                            (obj as Ball).updateyVelocity();
                            collisions.Items.Add("Ball Collided wall top.");
                        }

                        else if ((obj as Ball).getcurYPos() + (obj as Ball).getBallHeight() > balls_ground.Height)
                        {
                            (obj as Ball).updateyVelocity();
                            collisions.Items.Add("Ball Collided wall bottom.");
                            lives--;
                        }

                        

                    }
                }

                ballsCollide();

                ballsCollideWithBlocks();

            }
            else
            {
                observers.Clear();
                tmrMoveBall.Enabled = false;
                MessageBox.Show("You lost, your lives are finished");
            }

            balls_ground.Refresh();
        }

        public void ballCollisionWithPaddle(Observer obj)
        {
            if ((obj as Ball).getcurYPos() + (obj as Ball).getBallHeight() > paddle.Top && (obj as Ball).getcurYPos() + (obj as Ball).getBallHeight() <= paddle.Bottom && (obj as Ball).getcurYPos() + (obj as Ball).getBallWidth() > paddle.Left && (obj as Ball).getcurYPos() + (obj as Ball).getBallWidth() <= paddle.Right)
            {
                (obj as Ball).updateyVelocity();
                collisions.Items.Add("Ball Collided top with paddle");
                Boing();
            }
        }


        public int numberOfBlocks()
        {
            int count = observers.OfType<Block>().Count();

            return count;
        }

        public bool blocksExists()
        {
            return (observers.OfType<Block>().Count() > 0);
        }

        private static void Boing()
        {
            using (SoundPlayer player = new SoundPlayer(
                Properties.Resources.boing))
            {
                player.Play();
            }
        }


        private static void BallsCollide()
        {
            using (SoundPlayer player = new SoundPlayer(
                Properties.Resources.ball))
            {
                player.Play();
            }
        }


        //Balls collide with blocks
        public void ballsCollideWithBlocks()
        {
            foreach (Observer obj in observers.ToArray())
            {
                if (obj is Ball)
                {
                    Rectangle r1 = (obj as Ball).getBall();

                    foreach (Observer obj2 in observers.ToArray())
                    {
                        if ((obj2 is Block) && (obj) != (obj2))
                        {
                            Rectangle r2 = (obj2 as Block).getBlock();

                            r1.Intersect(r2);
                            if (!r1.IsEmpty)
                            {
                                (obj as Ball).updatexVelocity();
                                (obj as Ball).updateyVelocity();

                                (obj2 as Block).CollisionDetected();

                                if((obj2 as Block).collisions() == 1)
                                {
                                    Boing();
                                    (obj2 as Block).setFillBehaviour(new SolidBrush(Color.Gray));
                                }

                                if ((obj2 as Block).collisions() == 2)
                                {
                                    Boing();
                                    (obj2 as Block).setFillBehaviour(new SolidBrush(Color.LightGray));
                                }

                                if ((obj2 as Block).collisions() == 3)
                                {
                                    //observers.Remove(obj2);
                                    unitsObservers.removeObserver((obj2 as Observer));
                                }
                            }
                        }
                    }
                }
            }    
        }

        //Balls collide with ball
        private void ballsCollide()
        {
            foreach (Observer obj in observers)
            {
                if (obj is Ball)
                {
                    Rectangle r1 = (obj as Ball).getBall();

                    foreach (Observer obj2 in observers)
                    {
                        if ((obj2 is Ball) && (obj) != (obj2))
                        {
                            Rectangle r2 = (obj2 as Ball).getBall();

                            r1.Intersect(r2);
                            if (!r1.IsEmpty)
                            {
                                (obj as Ball).updatexVelocity();
                                (obj as Ball).updateyVelocity();

                                BallsCollide();

                                (obj2 as Ball).updatexVelocity();
                                (obj2 as Ball).updateyVelocity();
                            }
                        }
                    }
                 }
            }
        }

        // Draw the ball at its current location.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);

            observers = unitsObservers.getObservers();


            foreach (Observer obj in observers)
            {
                if (obj is Block){
                    e.Graphics.FillRectangle((obj as Block).getFilling(), (obj as Block).draw());
                    e.Graphics.DrawRectangle((obj as Block).getDrawing(), (obj as Block).draw());
                }
                else{
                    e.Graphics.FillEllipse((obj as Ball).getFilling(), (obj as Ball).draw());
                    e.Graphics.DrawEllipse((obj as Ball).getDrawing(), (obj as Ball).draw());
                }
            }
        }

        private void InstanceRectangleIntersection(PaintEventArgs e)
        {

            Rectangle rectangle1 = new Rectangle(50, 10, 200, 100);
            Rectangle rectangle2 = new Rectangle(70, 30, 100, 200);

            e.Graphics.DrawRectangle(Pens.Black, rectangle1);
            e.Graphics.DrawRectangle(Pens.Red, rectangle2);

            if (rectangle1.IntersectsWith(rectangle2))
            {
                rectangle1.Intersect(rectangle2);
                if (!rectangle1.IsEmpty)
                {
                    e.Graphics.FillRectangle(Brushes.Green, rectangle1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            unitsObservers.setVelocity(int.Parse(velocityX.Text), int.Parse(velocityY.Text));
        }

        private void paddle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                paddle.Left = paddle.Left + (e.X - currentX);
            }
        }

        private void paddle_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

            currentX = e.X;
        }

        private void paddle_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        // When a player clicks the left button, a new block will be spawned on the form using
        // the mouse’s current X and Y coordinates.
        private void unitGround_MouseDown(object sender, MouseEventArgs e)
        {
            using (Graphics g = this.balls_ground.CreateGraphics())
            {
                new Block("C1", "C1", 45, 45, e.X, e.Y, 0, 0, unitsObservers);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tmrMoveBall.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tmrMoveBall.Enabled = true;
        } 

        private void button8_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            unitFactory.createUnit("Ball", "A1", "A1", 30, 30,
                                        rnd.Next(0, balls_ground.Width - 2),
                                        rnd.Next(0, balls_ground.Height - 2),
                                        8, 8, unitsObservers);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            unregisterBall();
        }


        public void unregisterBall()
        {
            int i = 0,counter = 0,posOflastBall = 0;
            
            foreach(Observer obj in observers)
            {
                if (obj is Ball)
                {
                    if (obj is Ball)
                    {
                        i++;
                        posOflastBall = counter;
                    }
                }
                counter++;
            }

            if (i >= 4)
            {
                unitsObservers.removeObserver((observers[posOflastBall] as Observer));
            }
        }

        private void resetGame_Click(object sender, EventArgs e)
        {
            tmrMoveBall.Enabled = false;

            MessageBox.Show("Do you really want to restart the game?");

            resetTheGame();
        }

        private void resetTheGame()
        {
            lives = 50;

            collisions.Items.Clear();

            observers.Clear(); //Remove all elements in the ArrayList

            unitsObservers = new UnitsObservers();

            initializeBlocks();

            initializeBalls();

            observers = unitsObservers.getObservers();

            tmrMoveBall.Enabled = true;

        }

        private void decorateBall_Click(object sender, EventArgs e)
        {
            //ballToDecorate.decorate();

            observers[2] = (new ConcreteDecorate((observers[2] as Unit)) as Observer);

           //observers = unitsObservers.getObservers();

        }

        private void undecorateBall_Click(object sender, EventArgs e)
        {
            //ballToDecorate = new ConcreteUnDecorate(ballToDecorate);

            (ballToDecorate as Ball).undecorate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void ballcolide_Click(object sender, EventArgs e)
        {

        }
    }
}
