using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_JPWP
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
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
            if (_game.Map_counter <= 3)
                _game.Timer.Start();

            NavigationService.Navigate(_game);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

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
