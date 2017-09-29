namespace Logic.Attributes
{
    /// <summary>
    /// Defines the contract for GettingReadyCommand classes. While not all commands 
    /// will depend on the existence of WeatherType information, this design ensures
    /// the appropriate information will be present when it is needed.
    /// </summary>
    public interface IGettingReadyCommand
    {
        /// <summary>
        /// The Person instance on which this command will execute.
        /// </summary>
        Person Person { get; }

        /// <summary>
        /// The WeatherType used to make any conditional decisions
        /// that depend on the weather.
        /// </summary>
        WeatherType WeatherType { get; }

        /// <summary>
        /// Executes the defined command on the contained Person instance 
        /// using WeatherType if applicable.
        /// </summary>
        /// <returns>The text designating what was done.</returns>
        string Execute();
    }
}