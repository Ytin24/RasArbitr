using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasArbitrCore.Model
{
    public class StatusCodes
    {
        private static Dictionary<string, string?> statuses = new()
        {
            { "Все", null },
            { "Только завершенные", "1" },
            { "Только не завершённые", "0" },
        };

        private static string[] names = statuses.Keys.ToArray();
        public string[] Names
        {
            get => names;
        }

        public string GetCode(string TypeName)
        {
            return statuses.GetValueOrDefault(TypeName);
        }
    }
}
