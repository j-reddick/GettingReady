using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(2, "Put on headwear", typeof(PutOnHeadwearCommand))]
    public class PutOnHeadwearCommand : IGettingReadyCommand
    {
        private string output;

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnHeadwearCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            output = WeatherType == WeatherType.HOT ? "sun visor" : "hat";
        }

        public string Execute()
        {
            Person.Clothing.Add(new ClothingItem(output, ClothingType.Headwear));
            return output;
        }
    }
}

