using System.Windows;
using System.Windows.Navigation;

namespace Projekt_JPWP
{
    public partial class ScoreWindow : Window
    {
        private Game _game;

        public ScoreWindow(Game game)
        {
            InitializeComponent();
            Score.Content = game.Score.Content;
            Time.Content = game.Time.Content;
            _game = game;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _game.Timer.Start();
            _game.SelectMap();
            Close();
        }
    }
}
