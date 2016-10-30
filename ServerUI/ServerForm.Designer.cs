namespace ServerUI
{
    partial class ServerForm
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
            this.requestsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // requestsTextBox
            // 
            this.requestsTextBox.BackColor = System.Drawing.Color.White;
            this.requestsTextBox.Location = new System.Drawing.Point(12, 12);
            this.requestsTextBox.Multiline = true;
            this.requestsTextBox.Name = "requestsTextBox";
            this.requestsTextBox.ReadOnly = true;
            this.requestsTextBox.Size = new System.Drawing.Size(260, 238);
            this.requestsTextBox.TabIndex = 0;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.requestsTextBox);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox requestsTextBox;
    }
}

