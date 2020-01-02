using System.Windows;

namespace Projekt_JPWP
{
    /// <summary>
    /// Logika interakcji dla klasy ScoreWindow.xaml
    /// </summary>
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
