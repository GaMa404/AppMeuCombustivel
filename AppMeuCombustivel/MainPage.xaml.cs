namespace AppMeuCombustivel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            double preco_etanol = Convert.ToDouble(etanol.Text);
            double preco_gasolina = Convert.ToDouble(gasolina.Text);
            string msg;

            if(preco_etanol > (preco_gasolina*0.7))
            {
                msg = "Compensa gasolina";
            }
            else
            {
                msg = "Compensa o etanol";
            }
            DisplayAlertAsync("Resultado:", msg, "OK");
        }
    }
}
