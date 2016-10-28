namespace ClientUI
{
    partial class ClientForm
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
            this.viewButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.studentListBox = new System.Windows.Forms.ListBox();
            this.mathNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DisNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.OopNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.serverResponseTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mathNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OopNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(241, 12);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(75, 23);
            this.viewButton.TabIndex = 0;
            this.viewButton.Text = "Получить";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(241, 41);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Добавить";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // studentListBox
            // 
            this.studentListBox.FormattingEnabled = true;
            this.studentListBox.Location = new System.Drawing.Point(11, 27);
            this.studentListBox.Name = "studentListBox";
            this.studentListBox.Size = new System.Drawing.Size(96, 199);
            this.studentListBox.TabIndex = 2;
            this.studentListBox.SelectedIndexChanged += new System.EventHandler(this.studentListBox_SelectedIndexChanged);
            // 
            // mathNumericUpDown
            // 
            this.mathNumericUpDown.Location = new System.Drawing.Point(114, 81);
            this.mathNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.mathNumericUpDown.Name = "mathNumericUpDown";
            this.mathNumericUpDown.Size = new System.Drawing.Size(115, 20);
            this.mathNumericUpDown.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Математика";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "РИС";
            // 
            // DisNumericUpDown
            // 
            this.DisNumericUpDown.Location = new System.Drawing.Point(114, 128);
            this.DisNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.DisNumericUpDown.Name = "DisNumericUpDown";
            this.DisNumericUpDown.Size = new System.Drawing.Size(115, 20);
            this.DisNumericUpDown.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ООП";
            // 
            // OopNumericUpDown
            // 
            this.OopNumericUpDown.Location = new System.Drawing.Point(114, 177);
            this.OopNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.OopNumericUpDown.Name = "OopNumericUpDown";
            this.OopNumericUpDown.Size = new System.Drawing.Size(115, 20);
            this.OopNumericUpDown.TabIndex = 7;
            // 
            // serverResponseTextBox
            // 
            this.serverResponseTextBox.Location = new System.Drawing.Point(11, 245);
            this.serverResponseTextBox.Multiline = true;
            this.serverResponseTextBox.Name = "serverResponseTextBox";
            this.serverResponseTextBox.Size = new System.Drawing.Size(304, 183);
            this.serverResponseTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ответ сервера";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(241, 70);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 11;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(240, 99);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Сутденты";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(114, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Имя студента";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(117, 27);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(112, 20);
            this.nameTextBox.TabIndex = 15;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 440);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serverResponseTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OopNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DisNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mathNumericUpDown);
            this.Controls.Add(this.studentListBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.viewButton);
            this.Name = "ClientForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mathNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OopNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ListBox studentListBox;
        private System.Windows.Forms.NumericUpDown mathNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DisNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown OopNumericUpDown;
        private System.Windows.Forms.TextBox serverResponseTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}

