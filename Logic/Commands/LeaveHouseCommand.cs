using Logic.Clothing;

namespace Logic.Attributes
{
    [CommandAttributes(7, "Leave house", typeof(LeaveHouseCommand))]
    public class LeaveHouseCommand : IGettingReadyCommand
    {
        private string output;

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public LeaveHouseCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            output = "leaving house";
        }

        public string Execute()
        {
            Person.Status = "Left house";
            return output;
        }
    }
}

