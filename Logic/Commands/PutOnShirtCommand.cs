using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(4, "Put on shirt", typeof(PutOnShirtCommand))]
    public class PutOnShirtCommand : IGettingReadyCommand
    {
        private string output;

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnShirtCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            output = weatherType == WeatherType.HOT ? "t-shirt" : "shirt";
        }

        public string Execute()
        {
            Person.Clothing.Add(new ClothingItem(output, ClothingType.Shirt));
            return output;
        }
    }
}

