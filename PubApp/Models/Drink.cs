using System.Collections.Generic;
using System.Windows.Documents;

namespace PubApp.Models
{
    public class Drink
    {
        public string Name { get; set; }
        public string Hardness { get; set; }
        public decimal Price { get; set; }
        public List<int> Sizes { get; set; }
        public bool Favorite { get; set; }

        public void ChangeFavoriteStatus()
        {
            Favorite = !Favorite;
        }
    }
}