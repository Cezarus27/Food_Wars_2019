using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace Projekt_JPWP
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class Game : Page
    {
        private Plate _plate;
        private MapSetting _map;
        private Player _player;
        private DispatcherTimer _timer;

        private int _map_counter = 1;
        private int _second, _minute;

        public DispatcherTimer Timer { get => _timer;}
        public int Map_counter { get => _map_counter; }

        private enum _selectMap { first, second, third };
        public Game()
        {
            InitializeComponent();
            SelectMap();
            _player = new Player();
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        #region Map selection and clear, create a plate
        public void SelectMap()
        {
            if (_map_counter == 1)
                GenerateMap(_selectMap.first);
            else if (_map_counter == 2)
                GenerateMap(_selectMap.second);
            else if (_map_counter == 3)
                GenerateMap(_selectMap.third);
            else
            {
                _timer.Stop();
                Menu menu = new Menu(this);
                NavigationService.Navigate(menu);
            }
        }
        private void GenerateMap(_selectMap level)
        {
            switch (level)
            {
                case _selectMap.first:
                    WindowClear();

                    _map = new MapSetting((int)level);

                    CreatePlate(_map.MaxCalories, _map.ProductAtPlate);

                    foreach (Product p in _map.Products)
                        ProductsWrapPanel.Children.Add(p);

                    max_calories.Content = _plate.MaxCalories.ToString();

                    break;
                case _selectMap.second:
                    ResetTimer();
                    WindowClear();

                    _map = new MapSetting((int)level);

                    CreatePlate(_map.MaxCalories, _map.ProductAtPlate);

                    foreach (Product p in _map.Products)
                        ProductsWrapPanel.Children.Add(p);

                    max_calories.Content = _plate.MaxCalories.ToString();
                    break;
                case _selectMap.third:
                    ResetTimer();
                    WindowClear();

                    _map = new MapSetting((int)level);

                    CreatePlate(_map.MaxCalories, _map.ProductAtPlate);

                    foreach (Product p in _map.Products)
                        ProductsWrapPanel.Children.Add(p);

                    max_calories.Content = _plate.MaxCalories.ToString();
                    break;
            }
        }

        private void ResetTimer()
        {
            _second = 0;
            _minute = 0;
            Time.Content = "00:00";
        }

        private void WindowClear()
        {
            try
            {
                ProductsWrapPanel.Children.RemoveRange(0, ProductsWrapPanel.Children.Count);
                _plate.Children.RemoveRange(0, _plate.Children.Count);
                current_calories.Content = "0";
                _map.DeleteLists();
            }
            catch
            {
            }
        }
        //Create plate
        public void CreatePlate(int calories, int elements)
        {
            _plate = new Plate(calories);
            _plate.Name = "PlateWrapPanel";
            _plate.Width = 600;
            _plate.Height = 200;
            _plate.Margin = new Thickness(333, 330, 0, 0);
            _plate.Orientation = Orientation.Horizontal;
            _plate.HorizontalAlignment = HorizontalAlignment.Left;
            _plate.VerticalAlignment = VerticalAlignment.Top;
            _plate.Children.Capacity = elements;
            _plate.Background = Brushes.Transparent;
            _plate.AllowDrop = true;
            _plate.DragEnter += Plate_DragEnter;
            _plate.Drop += Plate_Drop;
            _plate.MouseDown += Products_MouseDown;
            rootGrid.Children.Add(_plate);
        }
        #endregion
        
        #region Events
        private void _timer_Tick(object sender, EventArgs e)
        {

            _second++;
            if (_second == 60)
            {
                _second = 0;
                _minute++;
            }
            else if (_minute == 60)
            {
                _minute = 0;
            }

            if (_minute < 10)
            {
                if (_second < 10)
                {
                    Time.Content = string.Format("0{0}:0{1}", _minute, _second);
                }
                else
                {
                    Time.Content = string.Format("0{0}:{1}", _minute, _second);
                }
            }
            else
            {
                if (_second < 10)
                {
                    Time.Content = string.Format("{0}:0{1}", _minute, _second);
                }
                else
                {
                    Time.Content = string.Format("{0}:{1}", _minute, _second);
                }
            }
        }

        private void Products_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point currentMousePosition = e.GetPosition(Food_Wars);
            WrapPanel panel = sender as WrapPanel;
            int topMargin = (int)panel.Margin.Top;
            int leftMargin = (int)panel.Margin.Left;
            int pictureTop = 0;
            int pictureBot = 0;
            int pictureLeft = 0;
            int pictureRight = 0;

            for (int i = 0; i < panel.Children.Count; i++)
            {
                Product food = panel.Children[i] as Product;

                if (panel.Name == "PlateWrapPanel")
                {
                    PositionAtPlate(i, leftMargin, topMargin, (int)food.Width, ref pictureLeft, ref pictureTop);
                }
                else if (panel.Name == "ProductsWrapPanel")
                {
                    PositionAtWrapPanel(i, leftMargin, topMargin, (int)food.Width, ref pictureLeft, ref pictureTop);
                }


                pictureBot = pictureTop + (int)food.Height;
                pictureRight = pictureLeft + (int)food.Width;

                if (currentMousePosition.X >= pictureLeft && currentMousePosition.X <= pictureRight
                    && currentMousePosition.Y >= pictureTop && currentMousePosition.Y <= pictureBot)
                    if (food != null && e.LeftButton == MouseButtonState.Pressed)
                    {
                        DragDrop.DoDragDrop(panel, food, DragDropEffects.Move);
                    }
            }
        }

        private void Plate_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = e.AllowedEffects;
        }

        private void Plate_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Product)))
            {
                Product dataReceived = e.Data.GetData(typeof(Product)) as Product;
                try
                {
                    if (_plate.Children.Capacity > _plate.Children.Count)
                    {
                        ProductsWrapPanel.Children.Remove(dataReceived);
                        _plate.Children.Add(dataReceived);
                        current_calories.Content = CountCalories().ToString();
                    }
                }
                catch
                {
                }

                if (CheckWin())
                    ShowScore();                
            }
        }

        private void ProductsWrapPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Product)))
            {
                Product dataReceived = e.Data.GetData(typeof(Product)) as Product;
                try
                {
                    _plate.Children.Remove(dataReceived);
                    ProductsWrapPanel.Children.Add(dataReceived);
                    current_calories.Content = CountCalories().ToString();
                }
                catch
                {
                }

                if (CheckWin())
                    ShowScore();
            }
        }
        private void ProductsWrapPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            WrapPanel panel = sender as WrapPanel;

            for (int i = 0; i < panel.Children.Count; i++)
            {
                Product food = panel.Children[i] as Product;
                ToolTip toolTip = new ToolTip();
                toolTip.Content = "Kalorie: " + food.Calories;
                food.ToolTip = toolTip;
            }
        }
        private void OnMenuClick(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            Menu menu = new Menu(this);
            NavigationService.Navigate(menu);
        }
        #endregion

        #region Position of each product at page
        private void PositionAtWrapPanel(int index, int leftMargin, int topMargin, int size, ref int pictureLeft, ref int pictureTop)
        {
            if (index < 6)
            {
                pictureLeft = leftMargin;
                pictureTop = topMargin + index * size;
            }
            else
            {
                pictureLeft = leftMargin + size;
                pictureTop = topMargin + (index - 6) * size;
            }
        }

        private void PositionAtPlate(int index, int leftMargin, int topMargin, int size, ref int pictureLeft, ref int pictureTop)
        {
            if (index < 6)
            {
                pictureLeft = leftMargin + index * size;
                pictureTop = topMargin;
            }
            else
            {
                pictureLeft = leftMargin + (index - 6) * size;
                pictureTop = topMargin + size;
            }
        }
        #endregion
        //Game logic
        public bool CheckWin()
        {
            bool winChecked = false;

            if (_plate.MaxCalories == CountCalories())
                winChecked = true;

            return winChecked;
        }

        private int CountCalories()
        {
            int amount = 0;

            foreach (Product p in _plate.Children)
            {
                amount = amount + p.Calories;
            }
            Console.WriteLine(amount);
            return amount;
        }

        private void ShowScore()
        {
            _timer.Stop();
            _map_counter = ++_map_counter;
            _player.ScoreCounter(_plate.MaxCalories, _minute, _second);
            Score.Content = _player.Score;

            ScoreWindow score = new ScoreWindow(this);
            score.Show();
        }

    }
}
