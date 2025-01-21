namespace ShoppingCart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Function or Method
        // 1. return data
        // 2. no return data
        double getPriceFromSelectedItems()
        {
            string strCoffeePrice = tbCoffeePrice.Text;
            string strCoffeeQuantity = tbCoffeeQuantity.Text;

            int iCoffeePrice = 0;
            int iCoffeeQuantity = 0;
            try
            {
                if (chbCoffee.Checked)
                {
                    iCoffeePrice = int.Parse(strCoffeePrice);
                    iCoffeeQuantity = int.Parse(strCoffeeQuantity);
                }
            }
            catch (Exception ex)
            {
                iCoffeePrice = 0;
                iCoffeeQuantity = 0;
            }
            int iPrice = iCoffeePrice * iCoffeeQuantity;
            double dTotal = getDiscountPrice(iPrice, "BEV");
            return dTotal;
        }
        /// <summary>
        /// Funtion to calculate item price with discount
        /// </summary>
        /// <param name="pTotal">total price of item</param>
        /// <param name="pType">type of item: ALL, BEV, FOOD</param>
        /// <returns></returns>
        double getDiscountPrice(int pTotal, string pType = "ALL")
        {
            double dDiscountBev = 0;
            if (chbDiscountBev.Checked)
                dDiscountBev = int.Parse(C.Text);
            return pTotal - (pTotal * dDiscountBev / 100);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dCash = double.Parse(tbCash.Text);
                double dBeverageTotal = 0;
                double dFoodTotal = 0;

                if (chbCoffee.Checked)
                {
                    dBeverageTotal += GetItemTotal(tbCoffeePrice.Text, tbCoffeeQuantity.Text);
                }
                if (chbGreenTea.Checked)
                {
                    dBeverageTotal += GetItemTotal(tbGreenTeaPrice.Text, tbGreenTeaQuantity.Text);
                }

                if (chbNoodle.Checked)
                {
                    dFoodTotal += GetItemTotal(tbNoodlePrice.Text, tbNoodleQuantity.Text);
                }
                if (chbPizza.Checked)
                {
                    dFoodTotal += GetItemTotal(tbPizzaPrice.Text, tbPizzaQuantity.Text);
                }

                double dGrandTotal = dBeverageTotal + dFoodTotal;

                double dTotalDiscount = CalculateTotalDiscount(dBeverageTotal, dFoodTotal, dGrandTotal);

                dGrandTotal -= dTotalDiscount;

                if (dCash < dGrandTotal)
                {
                    MessageBox.Show("เงินสดไม่เพียงพอ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double dChange = dCash - dGrandTotal;

                tbTotal.Text = dGrandTotal.ToString("F2");
                tbChange.Text = dChange.ToString("F2");

                CalculateChangeDenominations(dChange);
            }
            catch (FormatException)
            {
                MessageBox.Show("กรุณากรอกข้อมูลตัวเลขให้ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double GetItemTotal(string priceText, string quantityText)
        {
            double price = 0, quantity = 0;
            try
            {
                price = double.Parse(priceText);
                quantity = double.Parse(quantityText);
            }
            catch (Exception)
            {
                price = 0;
                quantity = 0;
            }
            return price * quantity;
        }
        private double CalculateTotalDiscount(double dBeverageTotal, double dFoodTotal, double dGrandTotal)
        {
            double dDiscountBev = chbDiscountBev.Checked ? double.Parse(chbDiscountBev.Text) : 0;
            double dDiscountFood = chbFood.Checked ? double.Parse(tbFood.Text) : 0;
            double dDiscountAll = chbAll.Checked ? double.Parse(tbAll.Text) : 0;

            double dTotalDiscount = (dBeverageTotal * dDiscountBev / 100) + (dFoodTotal * dDiscountFood / 100) + (dGrandTotal * dDiscountAll / 100);

            return dTotalDiscount;
        }

        private void CalculateChangeDenominations(double change)
        {
            double[] denominations = { 1000, 500, 100, 50, 20, 10, 5, 1, 0.50, 0.25 };
            int[] changeCount = new int[denominations.Length];
            double remainChange = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeCount[i] = (int)(remainChange / denominations[i]);
                remainChange %= denominations[i];
            }

            tb1000.Text = changeCount[0].ToString();
            tb500.Text = changeCount[1].ToString();
            tb100.Text = changeCount[2].ToString();
            tb50.Text = changeCount[3].ToString();
            tb20.Text = changeCount[4].ToString();
            tb10.Text = changeCount[5].ToString();
            tb5.Text = changeCount[6].ToString();
            tb1.Text = changeCount[7].ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbCoffeeQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

