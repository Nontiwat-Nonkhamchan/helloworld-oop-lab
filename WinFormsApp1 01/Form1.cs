namespace WinFormsApp1_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inputNum1 = num1.Text;
            var inputNum2 = num2.Text;

            double iNum1 = Int32.Parse(inputNum1);
            double iNum2 = Int32.Parse(inputNum2);
            double iResult = iNum1 + iNum2;
            result.Text = iResult.ToString();
        }

            private void button2_Click(object sender, EventArgs e)
            {
                var inputNum1 = num1.Text;
                var inputNum2 = num2.Text;

                double iNum1 = Int32.Parse(inputNum1);
                double iNum2 = Int32.Parse(inputNum2);
                double iResult = iNum1 * iNum2;
                result.Text = iResult.ToString();

            }
        

        private void button4_Click(object sender, EventArgs e)
        {
            var inputNum1 = num1.Text;
            var inputNum2 = num2.Text;

            double iNum1 = Int32.Parse(inputNum1);
            double iNum2 = Int32.Parse(inputNum2);
            double iResult = iNum1 / iNum2;
            result.Text = iResult.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string inputNum1 = num1.Text;
            string inputNum2 = num2.Text;

            int iNum1 = Int32.Parse(inputNum1);
            int iNum2 = Int32.Parse(inputNum2);
            int iResult = iNum1 + iNum2;

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var inputNum1 = num1.Text;
            var inputNum2 = num2.Text;

            double iNum1 = Int32.Parse(inputNum1);
            double iNum2 = Int32.Parse(inputNum2);
            double iResult = iNum1 - iNum2;
            result.Text = iResult.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            num1.Clear();
            num2.Clear();
            result.Clear();
        }
    }
}

