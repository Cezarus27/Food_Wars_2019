using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Plate plate;
        public MainWindow()
        {
            InitializeComponent();

            int mapNumber = 1;
            switch (mapNumber)
            {
                case 1:
                    MapSetting map = new MapSetting(mapNumber);
                    CreatePlate(map.MaxCalories);
                    foreach (Product p in map.Products)
                        ProductsStackPanel.Children.Add(p);
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        public void CreatePlate(int calories)
        {
            plate = new Plate(calories, 5);
            plate.Name = "PlateWrapPanel";
            plate.Width = 600;
            plate.Height = 200;
            plate.Margin = new Thickness(333, 330, 0, 0);
            plate.Orientation = Orientation.Horizontal;
            plate.HorizontalAlignment = HorizontalAlignment.Left;
            plate.VerticalAlignment = VerticalAlignment.Top;
            plate.Background = Brushes.Transparent;
            plate.AllowDrop = true;
            plate.DragEnter += Plate_DragEnter;
            plate.Drop += Plate_Drop;
            plate.MouseDown += Products_MouseDown;
            rootGrid.Children.Add(plate);
        }

        public bool CheckWin()
        {
            bool winChecked = false;

            //if (plate.MaxCalories == plate.Children[i]);

            return winChecked;
        }

        private void Products_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point currentMousePosition = e.GetPosition(Food_Wars_Window);
            Panel panel = sender as Panel;
            int topMargin = (int)panel.Margin.Top;
            int leftMargin = (int)panel.Margin.Left;
            int rightMargin = (int)panel.Width + topMargin;

            for (int i = 0; i < panel.Children.Count; i++)
            {              
                Product x = panel.Children[i] as Product;
                int pictureTop = topMargin + i * (int)x.Width;
                int pictureBot = pictureTop + (int)x.Width;

                if (currentMousePosition.X >= leftMargin && currentMousePosition.X <= rightMargin
                    && currentMousePosition.Y >= pictureTop && currentMousePosition.Y <= pictureBot)
                    if (x != null && e.LeftButton == MouseButtonState.Pressed)
                    {
                        DragDrop.DoDragDrop(panel, x, DragDropEffects.Move);
                    }               
            }
        }

        private void Plate_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = e.AllowedEffects;
        }

        private void Plate_Drop(object sender, DragEventArgs e)
        {
            Plate stackPanel = sender as Plate;

            if (e.Data.GetDataPresent(typeof(Product)))
            {
                Product dataReceived = e.Data.GetData(typeof(Product)) as Product;
                //for (int i = 0; i < panel.Children.Count; i++)
               // {
                   //Product p = panel.Children[i] as Product;
                   //if (dataReceived.Name != p.Name || i == 0)
                   //{
                        ProductsStackPanel.Children.Remove(dataReceived);
                        plate.Children.Add(dataReceived);
                   //} 
                //}    
            }
        }

        private void ProductsStackPanel_Drop(object sender, DragEventArgs e)
        {
            StackPanel stackPanel = sender as StackPanel;

            if (e.Data.GetDataPresent(typeof(Product)))
            {
                Product dataReceived = e.Data.GetData(typeof(Product)) as Product;

                plate.Children.Remove(dataReceived);
                ProductsStackPanel.Children.Add(dataReceived);
            }
        }
    }
}
