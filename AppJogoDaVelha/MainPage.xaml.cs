namespace AppJogoDaVelha;

public partial class MainPage : ContentPage
{
    string vez = "X";

    public MainPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;

        btn.IsEnabled = false;
        btn.Text = vez;

        // CORES
        if (vez == "X")
            btn.TextColor = Colors.Blue;
        else
            btn.TextColor = Colors.Red;

        if (VerificarVitoria())
        {
            DisplayAlert("Parabéns!", $"O jogador {vez} venceu!", "OK");
            Reiniciar();
            return;
        }

        if (VerificarEmpate())
        {
            DisplayAlert("Empate!", "Ninguém venceu!", "OK");
            Reiniciar();
            return;
        }

        vez = (vez == "X") ? "O" : "X";
    }

    bool VerificarVitoria()
    {
        if (btn00.Text == vez && btn01.Text == vez && btn02.Text == vez) return true;
        if (btn10.Text == vez && btn11.Text == vez && btn12.Text == vez) return true;
        if (btn20.Text == vez && btn21.Text == vez && btn22.Text == vez) return true;

        if (btn00.Text == vez && btn10.Text == vez && btn20.Text == vez) return true;
        if (btn01.Text == vez && btn11.Text == vez && btn21.Text == vez) return true;
        if (btn02.Text == vez && btn12.Text == vez && btn22.Text == vez) return true;

        if (btn00.Text == vez && btn11.Text == vez && btn22.Text == vez) return true;
        if (btn02.Text == vez && btn11.Text == vez && btn20.Text == vez) return true;

        return false;
    }

    bool VerificarEmpate()
    {
        return btn00.Text != "" && btn01.Text != "" && btn02.Text != "" &&
               btn10.Text != "" && btn11.Text != "" && btn12.Text != "" &&
               btn20.Text != "" && btn21.Text != "" && btn22.Text != "";
    }

    void Reiniciar()
    {
        Button[] botoes = { btn00, btn01, btn02, btn10, btn11, btn12, btn20, btn21, btn22 };

        foreach (var btn in botoes)
        {
            btn.Text = "";
            btn.IsEnabled = true;
        }

        vez = "X";
    }
}