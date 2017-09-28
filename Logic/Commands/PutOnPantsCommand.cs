using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(6, "Put on pants", typeof(PutOnPantsCommand))]
    public class PutOnPantsCommand : IGettingReadyCommand
    {
        public string Output { get; private set; }

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnPantsCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            Output = weatherType == WeatherType.HOT ? "shorts" : "pants";
        }

        public void Execute()
        {
            Person.Clothing.Add(new ClothingItem(Output, ClothingType.Pants));
        }
    }
}

