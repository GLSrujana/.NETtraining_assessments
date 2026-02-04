namespace MyFirstWinFormsApp
{
    public partial class Form1 : Form
    {

        // Change the type of textBox1 from object to TextBox
        // (Assuming textBox1 is already of type TextBox, as per the comment)

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Name:" + textBox4.Text;
            str += "\nFather's Name:" + textBox3.Text;
            str += "\nDate of Birth:" + dateTimePicker1.Text;
            str += "\nPreferences in Life:" + textBox1.Text;
            MessageBox.Show(str);
        }

    }
}
