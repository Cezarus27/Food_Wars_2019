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
        public int MaxCalories { get => _maxCalories; }
        public int ProductAtPlate { get => _productAtPlate;}

        private int mapSetting;
        private int _maxCalories;
        private int _productAtPlate;
        private static int[] _productCalories = { 60, 30, 20, 40, 400, 200, 150, 150, 75, 70, 320, 15 };
        private enum _allProducts{ apple, beetroot, bread, carrot, cooked_beef, cooked_chicken,
            cooked_cod, cooked_salmon, egg, potato, cooked_mutton, melon_slice};


        public MapSetting(int setNumber)
        {
            mapSetting = setNumber;
            switch(setNumber)
            {
                case 0:
                    ChooseProducts(3);
                    VictoryCondidtion(3);
                    break;
                case 1:
                    ChooseProducts(6);
                    VictoryCondidtion(4);
                    break;
                case 2:
                    ChooseProducts(10);
                    VictoryCondidtion(7);
                    break;
                case 3:
                    ChooseProducts(12);
                    VictoryCondidtion(8);
                    break;
            }
        }

        private void ChooseProducts(int productNumber)
        {
            if (productNumber != _productCalories.Length)
            {
                for (int i = 0; i < productNumber; i++)
                {
                    _allProducts p = (_allProducts)(new Random()).Next(12);
                    if (!ElementExist(p.ToString()))
                    {
                        int cal = ChooseCalories((int)p);
                        _calories.Add(cal);
                        CreateProduct(cal, p.ToString());
                    }
                    else
                        i--;
                }
            }
            else
                CreateAllProducts(productNumber);
        }

        private void CreateAllProducts(int productNumber)
        {
            for (int i = 0; i < productNumber; i++)
            {
                string name = Enum.GetName(typeof(_allProducts), i);
                CreateProduct(_productCalories[i], name);
                _calories.Add(_productCalories[i]);
            }
        }

        private void CreateProduct(int calories, string name)
        {
            Product product = new Product(calories);
            BitmapImage bitmap = new BitmapImage();
            //Load bitmap to memory
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.CreateOptions = BitmapCreateOptions.DelayCreation;
            bitmap.UriSource = new Uri("/Projekt_JPWP;component/img/" + name + ".png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();
            //set product properties
            product.BeginInit();
            product.Name = name;
            product.Source = bitmap;
            product.Width = 100;
            product.Height = 100;
            product.EndInit();

            _products.Add(product);
        }

        private int ChooseCalories(int tabIndex)
        {
            return _productCalories[tabIndex];
        }

        private void VictoryCondidtion(int elements)
        {
            _maxCalories = 0;
            _productAtPlate = elements;
            int[] tabIndex = new int[_calories.Count];

            for (int i = 0; i < _productAtPlate; i++)
            {
                if (_productAtPlate == _products.Count)
                {
                    _maxCalories =_maxCalories + _calories[i];
                }
                else
                {
                    int index = (new Random()).Next(_calories.Count);
                    if (!IndexExist(ref tabIndex, index))
                    {
                        tabIndex[i] = index;
                        _maxCalories = _maxCalories + _calories[index];
                    }                    
                    else
                        i--;
                }
            }
        }

        private bool IndexExist(ref int[] tabIndex, int index)
        {
            for (int i = 0; i < _calories.Count; i++)
            {
                if (tabIndex[i] == index)
                    return true;
            }
            return false;
        }

        private bool ElementExist(string name)
        {
            if (Products.Count != 0)
            {
                foreach (Product p in Products)
                {
                    if (p.Name == name)
                        return true;
                }
            }

            return false;
        }

        public void DeleteLists()
        {
            Products.RemoveRange(0, Products.Count);
            _calories.RemoveRange(0, _products.Count);
        }
    }
}
