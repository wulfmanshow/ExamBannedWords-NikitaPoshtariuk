namespace ExamBannedWords
{
    partial class Form1
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
            textBox1 = new TextBox();
            Add_Button = new Button();
            comboBox1 = new ComboBox();
            StartButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(116, 345);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // Add_Button
            // 
            Add_Button.Location = new Point(222, 345);
            Add_Button.Name = "Add_Button";
            Add_Button.Size = new Size(75, 23);
            Add_Button.TabIndex = 1;
            Add_Button.Text = "Add";
            Add_Button.UseVisualStyleBackColor = true;
            Add_Button.Click += AddButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Location = new Point(472, 166);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(237, 23);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(488, 345);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(221, 23);
            StartButton.TabIndex = 3;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StartButton);
            Controls.Add(comboBox1);
            Controls.Add(Add_Button);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosed += MainForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button Add_Button;
        private ComboBox comboBox1;
        private Button StartButton;
    }
}