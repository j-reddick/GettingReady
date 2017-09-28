using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(3, "Put on socks", typeof(PutOnSocksCommand))]
    public class PutOnSocksCommand : IGettingReadyCommand
    {
        public string Output { get; private set; }

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnSocksCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            Output = "socks";
        }

        public void Execute()
        {
            Person.Clothing.Add(new ClothingItem(Output, ClothingType.Socks));
        }
    }
}

