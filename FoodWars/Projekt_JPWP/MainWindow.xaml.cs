using System.Windows;

namespace Projekt_JPWP
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Game GamePage = new Game();
            GameFrame.Content = GamePage;
        }
    }
}
