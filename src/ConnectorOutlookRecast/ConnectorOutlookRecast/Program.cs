using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace ConnectorOutlookRecast
{
    class Program
    {

        static void Main(string[] args)
        {

            RecastContact bot2 = new RecastContact();
            ReponseRecast reponse2 = bot2.sendText("je voudrais changer de carete de tiers payant");

            WatsonContact watson = new WatsonContact();
            watson.sendText("je voudrais refaire ma carte ! ");



            Console.ReadKey();




            Email email = new Email();

            var count = email.emailBox.GetMessageCount();
            for (int i = count; i > 0; i--)
            {
                Message message = email.emailBox.GetMessage(i);
                if (message.Headers.Subject.ToLower().Contains("hackathon"))
                {
                    Console.WriteLine("----------------- Mail trouvé \\o/ ------------------");
                    Console.WriteLine("Information sur le mail");
                    Console.WriteLine("     Sujet:" + message.Headers.Subject);



                    string text;
                    try
                    {
                        text = message.MessagePart.MessageParts[0].GetBodyAsText();
                    }
                    catch(Exception ex)
                    {
                        text = message.MessagePart.MessageParts[1].GetBodyAsText();
                    }



                    text = cleanText(text);
                    string[] textSplit = splitSentence(text);

                    foreach (var item in textSplit)
                    {

                        Console.WriteLine("     Body:" + item);

                        Console.WriteLine("Envoie des informations au bot...");
                        RecastContact bot = new RecastContact();
                        ReponseRecast reponse = bot.sendText(item);

                        Console.WriteLine("");
                        if (string.IsNullOrEmpty(reponse.reply) && !string.IsNullOrEmpty(reponse.intent.slug))
                        {
                            Console.WriteLine("Zboubot: Intent => " + reponse.intent.slug);
                            Console.WriteLine("Zboubot: Confidence => " + reponse.intent.confidence);
                        }
                        else
                        {
                            Console.WriteLine("Zboubot est perdu: " + reponse.reply);
                        }

                        Console.WriteLine("");
                       
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else
                {
                   
                }
            }

            Console.WriteLine("Finit !!! ");
            Console.ReadKey();
        }

        public static string cleanText( string Text)
        {
            if (Text.ToLower().IndexOf("cordialement") > 0)
            {
                Text = Text.Remove(Text.ToLower().IndexOf("cordialement"));
            }

            if (Text.ToLower().IndexOf("_______________") > 0)
            {
                Text = Text.Remove(Text.ToLower().IndexOf("_______________"));
            }

            Text = Text.Replace("\n", "");
            Text = Text.Replace("\r", "");
            Text = Text.Replace("\"", "\\\"");
            return Text;
        }

        public static string[] splitSentence(string Text)
        {
            Text = Text.Replace(";", ".");
            Text = Text.Replace("!", ".");
            Text = Text.Replace("?", ".");
            return Text.Split('.');
        
        }
    }

}
