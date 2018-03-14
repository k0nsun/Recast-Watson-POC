using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorOutlookRecast
{
    public class ReponseWatson
    {
        public List<IntentWatson> intents = new List<IntentWatson>();

    }

    public class IntentWatson
    {
        public string confidence;
        public string intent;
    }
}
