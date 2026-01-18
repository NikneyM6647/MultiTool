
namespace MultiTool

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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            txtLog1 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(245, 69);
            button1.TabIndex = 0;
            button1.Text = "Create Folders";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(262, 12);
            button2.Name = "button2";
            button2.Size = new Size(229, 69);
            button2.TabIndex = 1;
            button2.Text = "Sort";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(497, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 69);
            button3.TabIndex = 2;
            button3.Text = "DevMode";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 87);
            button4.Name = "button4";
            button4.Size = new Size(560, 69);
            button4.TabIndex = 3;
            button4.Text = "Delete Test Folders";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // txtLog1
            // 
            txtLog1.Location = new Point(12, 162);
            txtLog1.Multiline = true;
            txtLog1.Name = "txtLog1";
            txtLog1.Size = new Size(560, 87);
            txtLog1.TabIndex = 4;
            txtLog1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 261);
            Controls.Add(txtLog1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox txtLog1;
    }
}
