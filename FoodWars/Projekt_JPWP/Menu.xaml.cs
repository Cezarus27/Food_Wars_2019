using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Food_Wars
{
    public partial class Menu : Page
    {
        private Game _game;

        public Menu(Game game)
        {
            InitializeComponent();
            _game = game;
        }

        private void BackToGame_Click(object sender, RoutedEventArgs e)
        {
            if (_game.Map_counter <= 4)
                _game.Timer.Start();

            NavigationService.Navigate(_game);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
           
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Game.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
