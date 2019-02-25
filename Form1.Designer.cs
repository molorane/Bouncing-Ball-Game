namespace BouncingBall
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tmrMoveBall = new System.Windows.Forms.Timer(this.components);
            this.balls_ground = new System.Windows.Forms.Panel();
            this.collisions = new System.Windows.Forms.ListBox();
            this.chances = new System.Windows.Forms.Label();
            this.blocks_left = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.velocityX = new System.Windows.Forms.TextBox();
            this.velocityY = new System.Windows.Forms.TextBox();
            this.resetGame = new System.Windows.Forms.Button();
            this.pauseGame = new System.Windows.Forms.Button();
            this.resumeGame = new System.Windows.Forms.Button();
            this.undecorateBall = new System.Windows.Forms.Button();
            this.decorateBall = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.decorateMethod = new System.Windows.Forms.Button();
            this.ballcolide = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tmrMoveBall
            // 
            this.tmrMoveBall.Enabled = true;
            this.tmrMoveBall.Interval = 16;
            this.tmrMoveBall.Tick += new System.EventHandler(this.tmrMoveBall_Tick);
            // 
            // balls_ground
            // 
            this.balls_ground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balls_ground.Location = new System.Drawing.Point(12, 9);
            this.balls_ground.Name = "balls_ground";
            this.balls_ground.Size = new System.Drawing.Size(623, 369);
            this.balls_ground.TabIndex = 0;
            this.balls_ground.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.balls_ground.MouseDown += new System.Windows.Forms.MouseEventHandler(this.unitGround_MouseDown);
            // 
            // collisions
            // 
            this.collisions.FormattingEnabled = true;
            this.collisions.Location = new System.Drawing.Point(653, 37);
            this.collisions.Name = "collisions";
            this.collisions.Size = new System.Drawing.Size(205, 342);
            this.collisions.TabIndex = 1;
            // 
            // chances
            // 
            this.chances.AutoSize = true;
            this.chances.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chances.Location = new System.Drawing.Point(681, 387);
            this.chances.Name = "chances";
            this.chances.Size = new System.Drawing.Size(97, 16);
            this.chances.TabIndex = 3;
            this.chances.Text = "Chances Left";
            // 
            // blocks_left
            // 
            this.blocks_left.AutoSize = true;
            this.blocks_left.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blocks_left.Location = new System.Drawing.Point(681, 9);
            this.blocks_left.Name = "blocks_left";
            this.blocks_left.Size = new System.Drawing.Size(88, 16);
            this.blocks_left.TabIndex = 2;
            this.blocks_left.Text = "Blocks Left:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Set Velocity";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // velocityX
            // 
            this.velocityX.Location = new System.Drawing.Point(130, 396);
            this.velocityX.Name = "velocityX";
            this.velocityX.Size = new System.Drawing.Size(45, 20);
            this.velocityX.TabIndex = 5;
            // 
            // velocityY
            // 
            this.velocityY.Location = new System.Drawing.Point(181, 396);
            this.velocityY.Name = "velocityY";
            this.velocityY.Size = new System.Drawing.Size(46, 20);
            this.velocityY.TabIndex = 6;
            // 
            // resetGame
            // 
            this.resetGame.Location = new System.Drawing.Point(22, 425);
            this.resetGame.Name = "resetGame";
            this.resetGame.Size = new System.Drawing.Size(75, 23);
            this.resetGame.TabIndex = 7;
            this.resetGame.Text = "Reset Game";
            this.resetGame.UseVisualStyleBackColor = true;
            this.resetGame.Click += new System.EventHandler(this.resetGame_Click);
            // 
            // pauseGame
            // 
            this.pauseGame.Location = new System.Drawing.Point(103, 426);
            this.pauseGame.Name = "pauseGame";
            this.pauseGame.Size = new System.Drawing.Size(47, 23);
            this.pauseGame.TabIndex = 8;
            this.pauseGame.Text = "Pause";
            this.pauseGame.UseVisualStyleBackColor = true;
            this.pauseGame.Click += new System.EventHandler(this.button3_Click);
            // 
            // resumeGame
            // 
            this.resumeGame.Location = new System.Drawing.Point(156, 426);
            this.resumeGame.Name = "resumeGame";
            this.resumeGame.Size = new System.Drawing.Size(62, 23);
            this.resumeGame.TabIndex = 9;
            this.resumeGame.Text = "Resume";
            this.resumeGame.UseVisualStyleBackColor = true;
            this.resumeGame.Click += new System.EventHandler(this.button4_Click);
            // 
            // undecorateBall
            // 
            this.undecorateBall.Location = new System.Drawing.Point(336, 425);
            this.undecorateBall.Name = "undecorateBall";
            this.undecorateBall.Size = new System.Drawing.Size(98, 23);
            this.undecorateBall.TabIndex = 10;
            this.undecorateBall.Text = "Undecorate Ball 1";
            this.undecorateBall.UseVisualStyleBackColor = true;
            this.undecorateBall.Click += new System.EventHandler(this.undecorateBall_Click);
            // 
            // decorateBall
            // 
            this.decorateBall.Location = new System.Drawing.Point(336, 395);
            this.decorateBall.Name = "decorateBall";
            this.decorateBall.Size = new System.Drawing.Size(98, 23);
            this.decorateBall.TabIndex = 11;
            this.decorateBall.Text = "Decorate Ball 1";
            this.decorateBall.UseVisualStyleBackColor = true;
            this.decorateBall.Click += new System.EventHandler(this.decorateBall_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(234, 425);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 23);
            this.button7.TabIndex = 12;
            this.button7.Text = "Unregister Ball 1";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(234, 396);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 23);
            this.button8.TabIndex = 13;
            this.button8.Text = "Register Ball 1";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // decorateMethod
            // 
            this.decorateMethod.Location = new System.Drawing.Point(440, 396);
            this.decorateMethod.Name = "decorateMethod";
            this.decorateMethod.Size = new System.Drawing.Size(92, 52);
            this.decorateMethod.TabIndex = 14;
            this.decorateMethod.Text = "Decorate Method";
            this.decorateMethod.UseVisualStyleBackColor = true;
            // 
            // ballcolide
            // 
            this.ballcolide.Location = new System.Drawing.Point(552, 411);
            this.ballcolide.Name = "ballcolide";
            this.ballcolide.Size = new System.Drawing.Size(83, 23);
            this.ballcolide.TabIndex = 15;
            this.ballcolide.Text = "Ball Collide";
            this.ballcolide.UseVisualStyleBackColor = true;
            this.ballcolide.Click += new System.EventHandler(this.ballcolide_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(716, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "About";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 473);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ballcolide);
            this.Controls.Add(this.decorateMethod);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.decorateBall);
            this.Controls.Add(this.undecorateBall);
            this.Controls.Add(this.resumeGame);
            this.Controls.Add(this.pauseGame);
            this.Controls.Add(this.resetGame);
            this.Controls.Add(this.velocityY);
            this.Controls.Add(this.velocityX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chances);
            this.Controls.Add(this.blocks_left);
            this.Controls.Add(this.collisions);
            this.Controls.Add(this.balls_ground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Breakout";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrMoveBall;
        private System.Windows.Forms.Panel balls_ground;
        private System.Windows.Forms.ListBox collisions;
        private System.Windows.Forms.Label chances;
        private System.Windows.Forms.Label blocks_left;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox velocityX;
        private System.Windows.Forms.TextBox velocityY;
        private System.Windows.Forms.Button resetGame;
        private System.Windows.Forms.Button pauseGame;
        private System.Windows.Forms.Button resumeGame;
        private System.Windows.Forms.Button undecorateBall;
        private System.Windows.Forms.Button decorateBall;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button decorateMethod;
        private System.Windows.Forms.Button ballcolide;
        private System.Windows.Forms.Button button2;
    }
}

