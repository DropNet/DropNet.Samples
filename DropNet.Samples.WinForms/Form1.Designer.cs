namespace DropNet.Samples.WinForms
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
            this.btn_LoginEmbed = new System.Windows.Forms.Button();
            this.brwLogin = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btn_LoginEmbed
            // 
            this.btn_LoginEmbed.Location = new System.Drawing.Point(9, 10);
            this.btn_LoginEmbed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_LoginEmbed.Name = "btn_LoginEmbed";
            this.btn_LoginEmbed.Size = new System.Drawing.Size(92, 50);
            this.btn_LoginEmbed.TabIndex = 0;
            this.btn_LoginEmbed.Text = "Login (Embedded Browser)";
            this.btn_LoginEmbed.UseVisualStyleBackColor = true;
            this.btn_LoginEmbed.Click += new System.EventHandler(this.btn_LoginEmbed_Click);
            // 
            // brwLogin
            // 
            this.brwLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brwLogin.Location = new System.Drawing.Point(9, 64);
            this.brwLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brwLogin.MinimumSize = new System.Drawing.Size(15, 16);
            this.brwLogin.Name = "brwLogin";
            this.brwLogin.Size = new System.Drawing.Size(412, 317);
            this.brwLogin.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 392);
            this.Controls.Add(this.brwLogin);
            this.Controls.Add(this.btn_LoginEmbed);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "DropNet.Sample.WinForms";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_LoginEmbed;
        private System.Windows.Forms.WebBrowser brwLogin;
    }
}

