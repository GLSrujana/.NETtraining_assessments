using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ADD button
        private void button1_Click(object sender, EventArgs e)
        {
            // Add country to DataGridView
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                dataGridView1.Rows.Add(textBox1.Text);
                textBox1.Clear();
            }

            // Add state to ComboBox
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                comboBox1.Items.Add(textBox2.Text);
                textBox2.Clear();
            }
        }

        // REMOVE COUNTRY button
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        // REMOVE STATE button
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                comboBox1.Items.Remove(comboBox1.SelectedItem);
            }
        }

        // SHOW DETAILS button
        private void button4_Click(object sender, EventArgs e)
        {
            if ((checkBox1.Checked || checkBox2.Checked) && radioButton1.Checked)
            {
                MessageBox.Show(
                    "Hello Mr, you will be contacted by either Postal Mail or Email",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else if ((checkBox1.Checked || checkBox2.Checked) && radioButton2.Checked)
            {
                MessageBox.Show(
                    "Hello Madam, you will be contacted by either Postal Mail or Email",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "Please select contact method and gender",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
