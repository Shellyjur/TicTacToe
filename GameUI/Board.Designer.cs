
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
            this.player1L.Location = new System.Drawing.Point(164, 600);
            this.player1L.Name = "player1L";
            this.player1L.Size = new System.Drawing.Size(83, 20);
            this.player1L.TabIndex = 0;
            this.player1L.Text = "m_Player1";
            // 
            // player2L
            // 
            this.player2L.AutoSize = true;
            this.player2L.Location = new System.Drawing.Point(502, 600);
            this.player2L.Name = "player2L";
            this.player2L.Size = new System.Drawing.Size(83, 20);
            this.player2L.TabIndex = 1;
            this.player2L.Text = "m_Player2";
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 680);
            this.Controls.Add(this.player2L);
            this.Controls.Add(this.player1L);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Board";
            this.Text = "TicTacToeMisere";
            this.Load += new System.EventHandler(this.Board_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label player1L;
        private System.Windows.Forms.Label player2L;
    }
}