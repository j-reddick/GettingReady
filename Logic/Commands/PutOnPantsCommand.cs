using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(6, "Put on pants", typeof(PutOnPantsCommand))]
    public class PutOnPantsCommand : IGettingReadyCommand
    {
        private string output;

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnPantsCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            output = weatherType == WeatherType.HOT ? "shorts" : "pants";
        }

        public string Execute()
        {
            Person.Clothing.Add(new ClothingItem(output, ClothingType.Pants));
            return output;
        }
    }
}

