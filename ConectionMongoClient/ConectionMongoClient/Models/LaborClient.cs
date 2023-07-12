using System.Text.Json;
using System.Text.Json.Nodes;

namespace ConectionMongoClient.Models
{
    public class LaborClient
    {
        private dynamic Financial;
        public Boolean IsEmployee { get; set; }
        public String ? JobName { get; set; }
        public String ? JobTitle { get; set; }
        public int ? salary { get; set; }
        public dynamic FinancialObligations {
            get { return Financial; }
            set { Financial = JsonSerializer.Serialize(value); }
        }

    }
}
