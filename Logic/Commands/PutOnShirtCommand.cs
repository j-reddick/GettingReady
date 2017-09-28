using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(4, "Put on shirt", typeof(PutOnShirtCommand))]
    public class PutOnShirtCommand : IGettingReadyCommand
    {
        public string Output { get; private set; }

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnShirtCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            Output = weatherType == WeatherType.HOT ? "t-shirt" : "shirt";
        }

        public void Execute()
        {
            Person.Clothing.Add(new ClothingItem(Output, ClothingType.Shirt));
        }
    }
}

