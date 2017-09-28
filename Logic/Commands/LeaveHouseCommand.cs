using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(7, "Leave house", typeof(LeaveHouseCommand))]
    public class LeaveHouseCommand : IGettingReadyCommand
    {
        public string Output { get; private set; }

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public LeaveHouseCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            Output = "leaving house";
        }

        public void Execute()
        {
            Person.Status = "Left house";
        }
    }
}

