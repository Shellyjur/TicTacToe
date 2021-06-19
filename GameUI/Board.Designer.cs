
namespace GameUI
{
    partial class Board
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
            this.player1L = new System.Windows.Forms.Label();
            this.player2L = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1L
            // 
            this.player1L.AutoSize = true;
            this.player1L.Location = new System.Drawing.Point(146, 480);
            this.player1L.Name = "player1L";
            this.player1L.Size = new System.Drawing.Size(56, 17);
            this.player1L.TabIndex = 0;
            this.player1L.Text = "Player1";
            // 
            // player2L
            // 
            this.player2L.AutoSize = true;
            this.player2L.Location = new System.Drawing.Point(446, 480);
            this.player2L.Name = "player2L";
            this.player2L.Size = new System.Drawing.Size(56, 17);
            this.player2L.TabIndex = 1;
            this.player2L.Text = "Player2";
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 544);
            this.Controls.Add(this.player2L);
            this.Controls.Add(this.player1L);
            this.Name = "Board";
            this.Text = "Board";
            this.Load += new System.EventHandler(this.Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player1L;
        private System.Windows.Forms.Label player2L;
    }
}