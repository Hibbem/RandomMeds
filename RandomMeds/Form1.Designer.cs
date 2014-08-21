namespace RandomMeds
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
            this.btnGo = new System.Windows.Forms.Button();
            this.lblRok = new System.Windows.Forms.Label();
            this.lblBok = new System.Windows.Forms.Label();
            this.lblBnot = new System.Windows.Forms.Label();
            this.lblRnot = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(374, 561);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go !";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblRok
            // 
            this.lblRok.AutoSize = true;
            this.lblRok.Location = new System.Drawing.Point(36, 566);
            this.lblRok.Name = "lblRok";
            this.lblRok.Size = new System.Drawing.Size(53, 13);
            this.lblRok.TabIndex = 1;
            this.lblRok.Text = "Raas OK:";
            // 
            // lblBok
            // 
            this.lblBok.AutoSize = true;
            this.lblBok.Location = new System.Drawing.Point(524, 561);
            this.lblBok.Name = "lblBok";
            this.lblBok.Size = new System.Drawing.Size(85, 13);
            this.lblBok.TabIndex = 2;
            this.lblBok.Text = "Betablokker OK:";
            // 
            // lblBnot
            // 
            this.lblBnot.AutoSize = true;
            this.lblBnot.Location = new System.Drawing.Point(524, 584);
            this.lblBnot.Name = "lblBnot";
            this.lblBnot.Size = new System.Drawing.Size(93, 13);
            this.lblBnot.TabIndex = 3;
            this.lblBnot.Text = "Betablokker NOT:";
            // 
            // lblRnot
            // 
            this.lblRnot.AutoSize = true;
            this.lblRnot.Location = new System.Drawing.Point(36, 584);
            this.lblRnot.Name = "lblRnot";
            this.lblRnot.Size = new System.Drawing.Size(61, 13);
            this.lblRnot.TabIndex = 4;
            this.lblRnot.Text = "Raas NOT:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 606);
            this.Controls.Add(this.lblRnot);
            this.Controls.Add(this.lblBnot);
            this.Controls.Add(this.lblBok);
            this.Controls.Add(this.lblRok);
            this.Controls.Add(this.btnGo);
            this.Name = "Form1";
            this.Text = "RandomMeds";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblRok;
        private System.Windows.Forms.Label lblBok;
        private System.Windows.Forms.Label lblBnot;
        private System.Windows.Forms.Label lblRnot;
    }
}

