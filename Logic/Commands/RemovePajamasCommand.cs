using Logic.Clothing;
using System.Linq;

namespace Logic.Attributes
{
    [CommandAttributes(8, "Take off pajamas", typeof(RemovePajamasCommand))]
    public class RemovePajamasCommand : IGettingReadyCommand
    {
        private string output;

        public Person Person { get; set; }

        public WeatherType WeatherType { get; set; }

        public RemovePajamasCommand(Person person, WeatherType weatherType)
        {
            Person = person;
            WeatherType = weatherType;
            output = "Removing PJs";
        }

        public string Execute()
        {
            var itemToRemove = Person?.Clothing?.First(item => item.ClothingType == ClothingType.Pajamas);
            Person?.Clothing?.Remove(itemToRemove);
            return output;
        }
    }
}
