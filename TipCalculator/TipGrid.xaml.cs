namespace TipCalculator
{
    public partial class TipGrid : ContentPage
    {
        bool arrendondaPraCima;
        bool arrendondaPraBaixo;

        public TipGrid()
	    {
		    InitializeComponent();
            tipPercentSliderGrid.ValueChanged += (s, e) => CalculateTip();
        }
    
        private void OnNormalTipGrid(object sender, EventArgs e)
        {
            tipPercentSliderGrid.Value = 15;
        }


        private void CalculateTip()
        {
            double valor = Convert.ToDouble(billInputGrid.Text);
            double percentualDaGorjeta = tipPercentSliderGrid.Value;
            double gorjeta = valor * (percentualDaGorjeta / 100);
            if (arrendondaPraCima)
            {
                gorjeta = Math.Ceiling(gorjeta);
            }
            if (arrendondaPraBaixo)
            {
                gorjeta = Math.Floor(gorjeta);
            }
            double total = valor + gorjeta;
            //Currency
            tipOutputGrid.Text = gorjeta.ToString("C");
            totalOutputGrid.Text = total.ToString("C");
            tipPercentGrid.Text = tipPercentSliderGrid.Value.ToString();
        }


        private void OnGenerousTipGrid(object sender, EventArgs e)
        {
            tipPercentSliderGrid.Value = 20;
        }

        private void roundUpGrid_Clicked(object sender, EventArgs e)
        {
            arrendondaPraCima = true;
            arrendondaPraBaixo = false;
        }

        private void roundDownGrid_Clicked(object sender, EventArgs e)
        {
            arrendondaPraCima = false;
            arrendondaPraBaixo = true;
        }

    }

}