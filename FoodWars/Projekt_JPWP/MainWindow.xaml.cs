using System.Windows;

namespace Food_Wars
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
