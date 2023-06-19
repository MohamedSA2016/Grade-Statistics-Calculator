

using Grade_Statistics_Calculator.ViewModel;

namespace Grade_Statistics_Calculator
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
        }

        private void OnAddScoreClicked(object sender, EventArgs e)
        {
            string input = scoreEntry.Text;
            viewModel.AddScores(input);
            scoreEntry.Text = string.Empty;
        }

        
    }
}
