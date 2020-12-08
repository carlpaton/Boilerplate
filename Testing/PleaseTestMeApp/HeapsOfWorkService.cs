namespace PleaseTestMeApp
{
    public class HeapsOfWorkService : IHeapsOfWorkService
    {
        public string MakeANoise(string reason)
        {
            return $"BOOMING NOISE! Because Im a {reason}!";
        }
    }

    /// <summary>
    /// Some service that does heaps of work :D #muchImportant
    /// </summary>
    public interface IHeapsOfWorkService 
    {
        /// <summary>
        /// Write out some noise!
        /// </summary>
        /// <param name="reason">
        /// What is the reason for your noise?
        /// </param>
        /// <returns></returns>
        string MakeANoise(string reason);
    }
}
