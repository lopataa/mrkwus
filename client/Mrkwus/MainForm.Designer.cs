
namespace MrkView
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RenderView = new System.Windows.Forms.Panel();
            this.ConnectPanel = new System.Windows.Forms.Panel();
            this.CreditsButton = new System.Windows.Forms.Button();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.RenderView.SuspendLayout();
            this.ConnectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RenderView
            // 
            this.RenderView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RenderView.Controls.Add(this.ConnectPanel);
            this.RenderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RenderView.Location = new System.Drawing.Point(0, 0);
            this.RenderView.Name = "RenderView";
            this.RenderView.Size = new System.Drawing.Size(509, 265);
            this.RenderView.TabIndex = 0;
            this.RenderView.Click += new System.EventHandler(this.RenderView_Click);
            this.RenderView.Paint += new System.Windows.Forms.PaintEventHandler(this.RenderView_Paint);
            this.RenderView.Resize += new System.EventHandler(this.RenderView_Resize);
            // 
            // ConnectPanel
            // 
            this.ConnectPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ConnectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConnectPanel.Controls.Add(this.CreditsButton);
            this.ConnectPanel.Controls.Add(this.UrlTextBox);
            this.ConnectPanel.Controls.Add(this.label3);
            this.ConnectPanel.Controls.Add(this.UsernameTextBox);
            this.ConnectPanel.Controls.Add(this.ConnectButton);
            this.ConnectPanel.Controls.Add(this.label2);
            this.ConnectPanel.Controls.Add(this.label1);
            this.ConnectPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConnectPanel.Location = new System.Drawing.Point(0, 0);
            this.ConnectPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConnectPanel.Name = "ConnectPanel";
            this.ConnectPanel.Size = new System.Drawing.Size(219, 263);
            this.ConnectPanel.TabIndex = 0;
            // 
            // CreditsButton
            // 
            this.CreditsButton.Location = new System.Drawing.Point(10, 152);
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.Size = new System.Drawing.Size(75, 23);
            this.CreditsButton.TabIndex = 6;
            this.CreditsButton.Text = "Credits";
            this.CreditsButton.UseVisualStyleBackColor = true;
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(10, 98);
            this.UrlTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(141, 23);
            this.UrlTextBox.TabIndex = 4;
            this.UrlTextBox.Text = "https://localhost/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "URL";
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(10, 56);
            this.UsernameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(141, 23);
            this.UsernameTextBox.TabIndex = 2;
            this.UsernameTextBox.TextChanged += new System.EventHandler(this.UsernameTextBox_TextChanged);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(10, 125);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(82, 22);
            this.ConnectButton.TabIndex = 5;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mrkwus";
            // 
            // Timer
            // 
            this.Timer.Interval = 16;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 265);
            this.Controls.Add(this.RenderView);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Pew";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Leave += new System.EventHandler(this.MainForm_Leave);
            this.RenderView.ResumeLayout(false);
            this.ConnectPanel.ResumeLayout(false);
            this.ConnectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel RenderView;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Panel ConnectPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreditsButton;
    }
}

