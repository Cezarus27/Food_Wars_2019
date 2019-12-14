using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Projekt_JPWP
{
    class Product : Image
    {
        private int calories;

        public Product(int calories)
        {
            this.calories = calories;
        }

        public int Calories { get => calories;}
    }
}
