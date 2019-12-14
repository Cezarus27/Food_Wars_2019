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
        public MainWindow()
        {
            InitializeComponent();
            PlateGrid.ShowGridLines = true;
            PlateStackPanel.AllowDrop = true;
            Map map = new Map();
            int mapNumber = 1;
            switch (mapNumber)
            {
                case 1:
                    map.CreateProducts(3);
                    map.CreatePlate(2);
                    foreach(Product p in map.Products)
                        ProductsStackPanel.Children.Add(p);
                    foreach (ColumnDefinition column in map.Columns)
                        PlateGrid.ColumnDefinitions.Add(column);
                    /*map.CreateProducts(3);
                    PlateGrid.Children.Add(map.Products[3]);
                    PlateGrid.Children.Add(map.Products[4]);
                    PlateGrid.Children.Add(map.Products[5]);*/
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private void ProductsStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point currentMousePosition = e.GetPosition(Food_Wars_Window);
            StackPanel stackPanel = sender as StackPanel;
            int topMargin = (int)stackPanel.Margin.Top;
            int leftMargin = (int)stackPanel.Margin.Left;
            int rightMargin = (int)stackPanel.Width + topMargin;
            int bottomMargin = (int)stackPanel.Height + leftMargin;
            Console.WriteLine(currentMousePosition.X + " " + currentMousePosition.Y);
            Console.WriteLine(topMargin);
            Console.WriteLine(leftMargin);
            Console.WriteLine(bottomMargin);
            Console.WriteLine(rightMargin);
            for (int i = 0; i < stackPanel.Children.Count; i++)
            {
                
                Product x = (Product)stackPanel.Children[i];
                int pictureTop = topMargin + i * (int)x.Width;
                int pictureBot = pictureTop + (int)x.Width;

                if (currentMousePosition.X >= leftMargin && currentMousePosition.X <= rightMargin
                    && currentMousePosition.Y >= pictureTop && currentMousePosition.Y <= pictureBot)
                    if (x != null && e.LeftButton == MouseButtonState.Pressed)
                    {
                        DragDrop.DoDragDrop(stackPanel, x, DragDropEffects.Copy);
                    }               
            }
        }

        /*private void PlateGrid_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = e.AllowedEffects;
        }

        private void PlateGrid_Drop(object sender, DragEventArgs e)
        {
            Product product = sender as Product;
            PlateGrid.Children.Add(product);
            /*if (e.Data.GetDataPresent(typeof(StackPanel)))
            {
                //StackPanel dataReceived = e.Data.GetData(typeof(StackPanel)) as StackPanel;
                //UIElement element = dataReceived.Children[0];
                PlateGrid.Children.Add(product);
            }*/
                

            /*if (e.Data.GetData(DataFormats.GetDataFormat()) != null)
            {
                (if (e.Data.GetDataPresent(DataFormats.Bitmap))
                {
                    Product dataReveived = (Product)e.Data.GetData(DataFormats.Bitmap);
                    product.Source = dataReveived.Source;
                }
            }
        }*/

        private void StackPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = e.AllowedEffects;
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            Product product = sender as Product;
            Console.WriteLine(e.Data.GetDataPresent(typeof(Product)));
            if (e.Data.GetDataPresent(typeof(Product)))
            {
                Product dataReceived = e.Data.GetData(typeof(Product)) as Product;
                string path = dataReceived.Name;
                dataReceived.Source = new BitmapImage(new Uri("/Projekt_JPWP;component/img/" + path + ".png", UriKind.RelativeOrAbsolute));
                PlateStackPanel.Children.Add(dataReceived);
            }
        }

        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(StackPanel)))
            {
                Product dataReceived = e.Data.GetData(typeof(Product)) as Product;
                PlateStackPanel.Children.Add(dataReceived);
            }
        }
    }
}
