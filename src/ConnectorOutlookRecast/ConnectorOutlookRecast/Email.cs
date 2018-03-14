using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConnectorOutlookRecast
{
    public class Email
    {
        public static string domain = "pop3.live.com";
        public static int port = 995;
        public static string email = "sunquan@hotmail.fr";
        public static string password = "co32csno$r";

        public Pop3Client emailBox;
        public Email()
        {
            emailBox = new Pop3Client();
            emailBox.Connect("pop3.live.com", 995, true);
            emailBox.Authenticate("sunquan@hotmail.fr", "co32csno$");
        }
    }
}
