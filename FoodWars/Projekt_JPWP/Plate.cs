using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Projekt_JPWP
{
    public class Plate : WrapPanel
    {
        private int maxCalories;

        public Plate(int calories)
        {
            maxCalories = calories;
        }

        public int MaxCalories { get => maxCalories;}

    }
}
