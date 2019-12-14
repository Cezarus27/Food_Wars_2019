using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projekt_JPWP
{
    public class Plate : Grid
    {
        private int maxCalories;
        private int maxNumProduct;

        public Plate(int calories, int productNumber)
        {
            maxCalories = calories;
            maxNumProduct = productNumber;
        }

        public int MaxCalories { get => maxCalories;}
        public int MaxNumProduct { get => maxNumProduct;}
    }
}
