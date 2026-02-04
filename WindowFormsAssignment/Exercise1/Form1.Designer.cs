namespace MyFirstWinFormsApp
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 60);
            label1.Name = "label1";
            label1.Size = new Size(117, 25);
            label1.TabIndex = 0;
            label1.Text = "Person Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(133, 112);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 1;
            label2.Text = "Father's Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(133, 167);
            label3.Name = "label3";
            label3.Size = new Size(115, 25);
            label3.TabIndex = 2;
            label3.Text = "Date Of Birth";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(133, 226);
            label4.Name = "label4";
            label4.Size = new Size(102, 25);
            label4.TabIndex = 3;
            label4.Text = "Preferences";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(305, 220);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(260, 31);
            textBox1.TabIndex = 4;
            textBox1.Text = "Investments";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(305, 106);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(260, 31);
            textBox3.TabIndex = 6;
            textBox3.Text = "Shyam";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(305, 54);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(260, 31);
            textBox4.TabIndex = 7;
            textBox4.Text = "Ram";
            // 
            // button1
            // 
            button1.Location = new Point(319, 279);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 8;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(305, 167);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(260, 31);
            dateTimePicker1.TabIndex = 9;
            dateTimePicker1.Value = new DateTime(1976, 7, 15, 15, 20, 0, 0);
            // 
            // Form1
            // 
            ClientSize = new Size(744, 340);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();

        }
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private DateTimePicker dateTimePicker1;
    }
}

#endregion
