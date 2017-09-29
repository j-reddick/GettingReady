using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(3, "Put on socks", typeof(PutOnSocksCommand))]
    public class PutOnSocksCommand : IGettingReadyCommand
    {
        private string output;

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnSocksCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            output = "socks";
        }

        public string Execute()
        {
            Person.Clothing.Add(new ClothingItem(output, ClothingType.Socks));
            return output;
        }
    }
}

