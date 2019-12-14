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
    class Map
    {
        private List<Product> _products = new List<Product>();
        private List<ColumnDefinition> _columns = new List<ColumnDefinition>();

        internal List<Product> Products { get => _products;}
        public List<ColumnDefinition> Columns { get => _columns; }

        private enum _allProducts{ apple, beetroot, bread, carrrot, cooked_beef, cooked_chicken,
            cooked_cod, cooked_salmon, egg, potato};

        public Map()
        {

        }

        public void CreateProducts(int productNumber)
        {
            string previewProduct = null;
            for (int i = 0; i < productNumber; i++)
            {
                _allProducts p = (_allProducts)(new Random()).Next(0, 10);
                if (previewProduct != p.ToString() || i == 0)
                {
                    Product product = new Product(100)
                    {
                        Name = p.ToString(),
                        Source = new BitmapImage(new Uri("/Projekt_JPWP;component/img/" + p.ToString() + ".png", 
                        UriKind.RelativeOrAbsolute)),
                        Width = 100,
                        Height = 100
                    };
                    
                    _products.Add(product);
                }
                else
                    i--;
                previewProduct = p.ToString();
            }
        }

        public void CreatePlate(int maxOnPlate)
        {
            Plate Plate = new Plate(300, maxOnPlate);
            for (int i = 0; i < maxOnPlate; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                _columns.Add(column);
            }
        }
    }
}
