namespace SerialAccept
{
    partial class ComPortSender
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
            this.buttonCloseComPortSender = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCloseComPortSender
            // 
            this.buttonCloseComPortSender.Location = new System.Drawing.Point(566, 404);
            this.buttonCloseComPortSender.Name = "buttonCloseComPortSender";
            this.buttonCloseComPortSender.Size = new System.Drawing.Size(115, 34);
            this.buttonCloseComPortSender.TabIndex = 0;
            this.buttonCloseComPortSender.Text = "Close Window";
            this.buttonCloseComPortSender.UseVisualStyleBackColor = true;
            this.buttonCloseComPortSender.Click += new System.EventHandler(this.buttonCloseComPortSender_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(256, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // ComPortSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCloseComPortSender);
            this.Name = "ComPortSender";
            this.Text = "ComPortSender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCloseComPortSender;
        private System.Windows.Forms.TextBox textBox1;
    }
}