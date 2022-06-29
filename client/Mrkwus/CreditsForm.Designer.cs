
namespace MrkView
{
    partial class CreditsForm
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
            this.ColorTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LopataaText = new System.Windows.Forms.Label();
            this.ZexypLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ColorTimer
            // 
            this.ColorTimer.Enabled = true;
            this.ColorTimer.Interval = 16;
            this.ColorTimer.Tick += new System.EventHandler(this.ColorTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mrkwus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version: Idk.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "made with love and care by";
            // 
            // LopataaText
            // 
            this.LopataaText.AutoSize = true;
            this.LopataaText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LopataaText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LopataaText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LopataaText.Location = new System.Drawing.Point(12, 83);
            this.LopataaText.Name = "LopataaText";
            this.LopataaText.Size = new System.Drawing.Size(65, 20);
            this.LopataaText.TabIndex = 4;
            this.LopataaText.Text = "Lopataa";
            this.LopataaText.Click += new System.EventHandler(this.LopataaText_Click);
            // 
            // ZexypLabel
            // 
            this.ZexypLabel.AutoSize = true;
            this.ZexypLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZexypLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ZexypLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(215)))), ((int)(((byte)(31)))));
            this.ZexypLabel.Location = new System.Drawing.Point(83, 83);
            this.ZexypLabel.Name = "ZexypLabel";
            this.ZexypLabel.Size = new System.Drawing.Size(51, 20);
            this.ZexypLabel.TabIndex = 5;
            this.ZexypLabel.Text = "Zexyp";
            this.ZexypLabel.Click += new System.EventHandler(this.ZexypLabel_Click);
            // 
            // CreditsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(219, 125);
            this.Controls.Add(this.LopataaText);
            this.Controls.Add(this.ZexypLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CreditsForm";
            this.Text = "Credits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ColorTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LopataaText;
        private System.Windows.Forms.Label ZexypLabel;
    }
}