using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELogging
{
   public class LogManager
    {
       public static void Log(Exception exception)
       {
           StringBuilder errorMessage = new StringBuilder();
           errorMessage.AppendFormat("Time:{0}", DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt"));
           errorMessage.Append(Environment.NewLine);
           errorMessage.Append("----------------------------------------------------------");

           errorMessage.Append(Environment.NewLine);
           errorMessage.AppendFormat("Message:{0}", exception.Message);
           errorMessage.Append(Environment.NewLine); 
           string path = ConfigurationManager.AppSettings["logFilePath"];

           if (!File.Exists(path))
           {
               File.Create(path);
           }

           StreamWriter streamWriter = new StreamWriter(path, true);
           streamWriter.WriteLine(errorMessage);
           streamWriter.Close();

       }
    }
}
