using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(1, "Put on footwear", typeof(PutOnFootwearCommand))]
    public class PutOnFootwearCommand : IGettingReadyCommand
    {
        private string output;

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnFootwearCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            output = WeatherType == WeatherType.HOT ? "sandals" : "boots";
        }

        public string Execute()
        {
            Person.Clothing.Add(new ClothingItem(output, ClothingType.Footwear));
            return output;
        }
    }
}

