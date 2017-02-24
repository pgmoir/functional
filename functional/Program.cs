using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace functional
{
    class Program
    {
        private static string BuildSelectBox(IDictionary<int, string> options, string id, bool includeUnknown)
        {
            var html = new StringBuilder();
            html.AppendFormat("<select id=\"{0}\" name=\"{0}\">", id);
            html.AppendLine();

            if (includeUnknown)
            {
                html.AppendLine("\t<option>Unknown</option>");
            }

            foreach (var opt in options)
            {
                html.AppendFormat("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value);
                html.AppendLine();
            }

            html.AppendLine("</select>");

            return html.ToString();
        }

        static void Main(string[] args)
        {
            var selections = new Dictionary<int, string>
            {
                {1, "Joe Bloggs"},
                {2, "Jess Smith"},
                {3, "Cary Grant"},
                {4, "Jason Bourne"},
                {5, "Bilbo Baggins"},
                {6, "Hugh McCarthy"},
                {7, "Joe Giggins"},
                {8, "Wesley Snipes"},
                {9, "Denzel Washington"},
                {10, "Sam Adams"}
            };


            Console.Write(BuildSelectBox(selections, "names", true));
            Console.ReadKey();
        }
    }
}
