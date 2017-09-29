using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(5, "Put on jacket", typeof(PutOnJacketCommand))]
    public class PutOnJacketCommand : IGettingReadyCommand
    {
        private string output;

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnJacketCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            output = "jacket";
        }

        public string Execute()
        {
            Person.Clothing.Add(new ClothingItem(output, ClothingType.Jacket));
            return output;
        }
    }
}

