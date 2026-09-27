using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.String_StringBuilder
{
    internal class TaskStringbuilder2
    {
        public static void Main()
        {
            Console.WriteLine("Enter log (format: ID | level | message):");
            string input = Console.ReadLine() ?? string.Empty;

            // split by '|'
            var parts = input.Split(new[] { '|' }, StringSplitOptions.None)
                .Select(p => p.Trim()).ToArray();

            string id = parts.Length > 0 ? parts[0] : string.Empty;
            string level = parts.Length > 1 ? parts[1].ToUpperInvariant() : string.Empty;
            string message = parts.Length > 2 ? parts[2].Trim() : string.Empty;

            // Normalize message: lowercase then capitalize first letter
            if (!string.IsNullOrEmpty(message))
            {
                message = message.ToLower();
                message = char.ToUpper(message[0]) + message.Substring(1);
            }

            string status;
            switch (level)
            {
                case "ERROR":
                    status = "Critical";
                    break;
                case "WARN":
                case "WARNING":
                    status = "Warning";
                    break;
                case "INFO":
                    status = "Info";
                    break;
                default:
                    status = "Unknown";
                    break;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Log ID      : {id}");
            sb.AppendLine($"Log Level   : {level}");
            sb.AppendLine($"Log Message : {message}");
            sb.AppendLine($"Status      : {status}");
            sb.AppendLine(new string('-', 110));

            Console.WriteLine(sb.ToString());
        }
    }
}
