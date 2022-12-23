namespace RasArbitrCore.Model
{
    public class Years
    {
        const int minYear = 2000;

        public Years()
        {
            int maxYear = DateTime.Now.Year + 6;
            for (int i = minYear; i <= maxYear; i++)
            {
                docYears.Add(i.ToString());
            }
        }

        private static List<string> docYears = new() { string.Empty };
        public List<string> DocYears
        {
            get => docYears;
        }
    }
}
