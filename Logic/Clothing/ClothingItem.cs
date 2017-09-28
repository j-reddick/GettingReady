namespace Logic.Clothing
{
    public class ClothingItem
    {
        public string Name { get; set; }
        public ClothingType ClothingType { get; private set; }

        public ClothingItem(string name, ClothingType clothingType)
        {
            Name = name;
            ClothingType = clothingType;
        }
    }
}
