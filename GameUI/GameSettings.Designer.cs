
namespace GameUI
{
    partial class GameSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.player1NameTB = new System.Windows.Forms.TextBox();
            this.player2CB = new System.Windows.Forms.CheckBox();
            this.player2NameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.nUDRows = new System.Windows.Forms.NumericUpDown();
            this.nUDCols = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(48, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player1:";
            // 
            // player1NameTB
            // 
            this.player1NameTB.Location = new System.Drawing.Point(160, 66);
            this.player1NameTB.Name = "player1NameTB";
            this.player1NameTB.Size = new System.Drawing.Size(100, 22);
            this.player1NameTB.TabIndex = 0;
            this.player1NameTB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // player2CB
            // 
            this.player2CB.AutoSize = true;
            this.player2CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.player2CB.Location = new System.Drawing.Point(52, 96);
            this.player2CB.Name = "player2CB";
            this.player2CB.Size = new System.Drawing.Size(92, 24);
            this.player2CB.TabIndex = 1;
            this.player2CB.Text = "&Player2:";
            this.player2CB.UseVisualStyleBackColor = true;
            this.player2CB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // player2NameTB
            // 
            this.player2NameTB.Enabled = false;
            this.player2NameTB.Location = new System.Drawing.Point(160, 98);
            this.player2NameTB.Name = "player2NameTB";
            this.player2NameTB.Size = new System.Drawing.Size(100, 22);
            this.player2NameTB.TabIndex = 2;
            this.player2NameTB.Text = "[Computer]";
            this.player2NameTB.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Board Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "&Rows:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "&Cols:";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(106, 265);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(154, 23);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "&Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // nUDRows
            // 
            this.nUDRows.Location = new System.Drawing.Point(118, 216);
            this.nUDRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUDRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDRows.Name = "nUDRows";
            this.nUDRows.Size = new System.Drawing.Size(47, 22);
            this.nUDRows.TabIndex = 3;
            this.nUDRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDRows.ValueChanged += new System.EventHandler(this.nUDRows_ValueChanged);
            // 
            // nUDCols
            // 
            this.nUDCols.Location = new System.Drawing.Point(259, 214);
            this.nUDCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUDCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDCols.Name = "nUDCols";
            this.nUDCols.Size = new System.Drawing.Size(54, 22);
            this.nUDCols.TabIndex = 4;
            this.nUDCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nUDCols.ValueChanged += new System.EventHandler(this.nUDCols_ValueChanged);
            // 
            // GameSettings
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 326);
            this.Controls.Add(this.nUDCols);
            this.Controls.Add(this.nUDRows);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.player2NameTB);
            this.Controls.Add(this.player2CB);
            this.Controls.Add(this.player1NameTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings:";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUDRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox player1NameTB;
        private System.Windows.Forms.CheckBox player2CB;
        private System.Windows.Forms.TextBox player2NameTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.NumericUpDown nUDRows;
        private System.Windows.Forms.NumericUpDown nUDCols;
    }
}

