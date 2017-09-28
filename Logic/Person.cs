using Logic.Clothing;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Person
    {
        public List<ClothingItem> Clothing { get; set; } = new List<ClothingItem>();
        public string Status { get; set; } = "In house";

        public Person()
        {
            Clothing.Add(new ClothingItem("pajamas", ClothingType.Pajamas));
        }

        /// <summary>
        /// Evaluates whether the person is wearing the specified type of clothing.
        /// </summary>
        /// <param name="clothingType">The clothing type to check for.</param>
        /// <returns>The boolean value indicating whether the person is wearing the passed clothing type.</returns>
        public bool IsWearing(ClothingType clothingType)
        {
            return Clothing.Any(item => item.ClothingType == clothingType);
        }
    }
}
