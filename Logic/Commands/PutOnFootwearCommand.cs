using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(1, "Put on footwear", typeof(PutOnFootwearCommand))]
    public class PutOnFootwearCommand : IGettingReadyCommand
    {
        public string Output { get; private set; }

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnFootwearCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            Output = WeatherType == WeatherType.HOT ? "sandals" : "boots";
        }

        public void Execute()
        {
            Person.Clothing.Add(new ClothingItem(Output, ClothingType.Footwear));
        }
    }
}

