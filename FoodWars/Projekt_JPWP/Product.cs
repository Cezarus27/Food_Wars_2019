using System.Windows.Controls;

namespace Food_Wars
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
