﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectorOutlookRecast
{
   public class ReponseRecast
    {
     
        public string conversationToken;
        public string reply;
        public IntentRecast intent = new IntentRecast();
        public Entities entities = new Entities();
    }

    public class IntentRecast
    {
        public string confidence;
        public string slug;
    }

    public class Entities
    {
       public List<entity> card = new List<entity>();
        public entity location;
        //public entity card;
    }

    public class entity
    {
        public string raw;
    }
}
