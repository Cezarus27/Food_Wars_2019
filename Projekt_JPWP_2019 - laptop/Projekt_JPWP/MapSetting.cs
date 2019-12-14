using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Projekt_JPWP
{
    class MapSetting
    {
        private List<Product> _products = new List<Product>();
        private List<int> _calories = new List<int>();

        internal List<Product> Products { get => _products;}
        public List<int> Calories { get => _calories; }
        public int MaxCalories { get => _maxCalories; }

        private int mapSetting;
        private int _maxCalories;
        private static int[] _productCalories = { 60, 30, 20, 40, 400, 200, 150, 150, 75, 70 };
        private enum _allProducts{ apple, beetroot, bread, carrrot, cooked_beef, cooked_chicken,
            cooked_cod, cooked_salmon, egg, potato};


        public MapSetting(int setNumber)
        {
            mapSetting = setNumber;
            switch(setNumber)
            {
                case 1:
                    ChooseProducts(3);
                    VictoryCondidtion();
                    break;
                case 2:
                    ChooseProducts(6);
                    VictoryCondidtion();
                    break;
                case 3:
                    ChooseProducts(10);
                    VictoryCondidtion();
                    break;

            }
        }

        private void ChooseProducts(int productNumber)
        {
            string previewProduct = null;
            for (int i = 0; i < productNumber; i++)
            {
                _allProducts p = (_allProducts)(new Random()).Next(0, 9);
                if (previewProduct != p.ToString() || i == 0)
                {
                    int cal = ChooseCalories((int)p);
                    _calories.Add(cal);

                    Product product = new Product(cal);
                    BitmapImage bitmap = new BitmapImage();
                    //Load bitmap to memory
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.CreateOptions = BitmapCreateOptions.DelayCreation;
                    bitmap.UriSource = new Uri("/Projekt_JPWP;component/img/" + p.ToString() + ".png",
                        UriKind.RelativeOrAbsolute);
                    bitmap.EndInit();
                    //set product properties
                    product.BeginInit();
                    product.Name = p.ToString();
                    product.Source = bitmap;
                    product.Width = 100;
                    product.Height = 100;
                    product.EndInit();

                    _products.Add(product);
                }
                else
                    i--;
                previewProduct = p.ToString();
            }
        }

        private int ChooseCalories(int tabIndex)
        {
            return _productCalories[tabIndex];
        }

        private void VictoryCondidtion()
        {
            _maxCalories = 0;
            int previewIndex = 0;
            for (int i = 0; i < _calories.Count - 1; i++)
            {
                int index = (new Random()).Next(_calories.Count);
                if (previewIndex != index)
                    _maxCalories = _maxCalories + _productCalories[index];
                else
                    i--;
                previewIndex = index;
            }
        }
    }
}
