using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace functional
{
    public static class StringBuilderExtensions
    {
        //public static StringBuilder AppendFormattedLine(
        //    this StringBuilder @this, 
        //    string format, 
        //    params object[] args) => @this.AppendFormat(format, args).AppendLine();

        public static StringBuilder AppendFormattedLine(
            this StringBuilder @this,
            string format,
            params object[] args)
        {
            return @this.AppendFormat(format, args).AppendLine();
        }

        public static StringBuilder AppendLineWhen(
            this StringBuilder @this,
            Func<bool> predicate,
            Func<StringBuilder, StringBuilder> fn)
        {
            return predicate() ? fn(@this) : @this;
        }

        public static StringBuilder AppendSequence<T>(
            this StringBuilder @this,
            IEnumerable<T> seq,
            Func<StringBuilder, T, StringBuilder> fn)
        {
            return seq.Aggregate(@this, fn);
        }
    }

    class Program
    {
        private static string BuildSelectBox(IDictionary<int, string> options, string id, bool includeUnknown)
        {
            return new StringBuilder()
                .AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)
                .AppendLineWhen(() => includeUnknown, sb => sb.AppendLine("\t<option>Unknown</option>"))
                .AppendSequence(options, (sb, opt) => sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
                .AppendLine("</select>")
                .ToString();
        }

        static void Main()
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
