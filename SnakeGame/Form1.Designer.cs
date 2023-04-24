namespace SnakeGame
{
    partial class ScrSnake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScrSnake));
            this.PickGameBoard = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PickGameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // PickGameBoard
            // 
            this.PickGameBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PickGameBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PickGameBoard.Location = new System.Drawing.Point(7, 6);
            this.PickGameBoard.Name = "PickGameBoard";
            this.PickGameBoard.Size = new System.Drawing.Size(550, 550);
            this.PickGameBoard.TabIndex = 0;
            this.PickGameBoard.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "E1.png");
            this.ImageList.Images.SetKeyName(1, "E2.png");
            this.ImageList.Images.SetKeyName(2, "E3.png");
            this.ImageList.Images.SetKeyName(3, "E4.png");
            this.ImageList.Images.SetKeyName(4, "E5.png");
            this.ImageList.Images.SetKeyName(5, "E6.png");
            this.ImageList.Images.SetKeyName(6, "E7.png");
            this.ImageList.Images.SetKeyName(7, "F1.png");
            this.ImageList.Images.SetKeyName(8, "F2.png");
            this.ImageList.Images.SetKeyName(9, "F3.png");
            this.ImageList.Images.SetKeyName(10, "S111.png");
            this.ImageList.Images.SetKeyName(11, "S22.png");
            this.ImageList.Images.SetKeyName(12, "W.png");
            // 
            // ScrSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 564);
            this.Controls.Add(this.PickGameBoard);
            this.Name = "ScrSnake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScrSnake_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.snake_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PickGameBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PickGameBoard;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.Timer timer;
    }
}

