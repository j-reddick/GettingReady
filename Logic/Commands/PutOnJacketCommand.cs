using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(5, "Put on jacket", typeof(PutOnJacketCommand))]
    public class PutOnJacketCommand : IGettingReadyCommand
    {
        public string Output { get; private set; }

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public PutOnJacketCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            Output = "jacket";
        }

        public void Execute()
        {
            Person.Clothing.Add(new ClothingItem(Output, ClothingType.Jacket));
        }
    }
}

