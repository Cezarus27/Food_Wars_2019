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
