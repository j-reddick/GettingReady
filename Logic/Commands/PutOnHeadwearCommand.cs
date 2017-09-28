using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(2, "Put on headwear", typeof(PutOnHeadwearCommand))]
    public class PutOnHeadwearCommand : IGettingReadyCommand
    {
        public string Output { get; private set; }

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnHeadwearCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            Output = WeatherType == WeatherType.HOT ? "sun visor" : "hat";
        }

        public void Execute()
        {
            Person.Clothing.Add(new ClothingItem(Output, ClothingType.Headwear));
        }
    }
}

