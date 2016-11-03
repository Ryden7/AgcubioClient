namespace CubioGUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FPS = new System.Windows.Forms.Label();
            this.Food = new System.Windows.Forms.Label();
            this.Mass = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(835, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME TO AGCUBIO";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(611, 267);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(611, 375);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(357, 267);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 375);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "IP / Server Name:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(521, 484);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FPS
            // 
            this.FPS.AutoSize = true;
            this.FPS.Location = new System.Drawing.Point(1183, 11);
            this.FPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FPS.Name = "FPS";
            this.FPS.Size = new System.Drawing.Size(64, 17);
            this.FPS.TabIndex = 6;
            this.FPS.Text = "FPS FPS";
            // 
            // Food
            // 
            this.Food.AutoSize = true;
            this.Food.Location = new System.Drawing.Point(1183, 27);
            this.Food.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Food.Name = "Food";
            this.Food.Size = new System.Drawing.Size(76, 17);
            this.Food.TabIndex = 7;
            this.Food.Text = "Food Food";
            // 
            // Mass
            // 
            this.Mass.AutoSize = true;
            this.Mass.Location = new System.Drawing.Point(1183, 43);
            this.Mass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Mass.Name = "Mass";
            this.Mass.Size = new System.Drawing.Size(78, 17);
            this.Mass.TabIndex = 8;
            this.Mass.Text = "Mass Mass";
            // 
            // Width
            // 
            this.Width.AutoSize = true;
            this.Width.Location = new System.Drawing.Point(1183, 59);
            this.Width.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(84, 17);
            this.Width.TabIndex = 9;
            this.Width.Text = "Width Width";
            // 
            // Form1
            // 
           // this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.Mass);
            this.Controls.Add(this.Food);
            this.Controls.Add(this.FPS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label FPS;
        private System.Windows.Forms.Label Food;
        private System.Windows.Forms.Label Mass;
        private System.Windows.Forms.Label Width;
    }
}