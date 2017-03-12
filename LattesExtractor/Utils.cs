using System;
using System.Text.RegularExpressions;

namespace LattesExtractor
{
    class Utils
    {
        private static Regex _issnRegex = new Regex("([^0-9Xx])");

        internal static Regex IssnRegex { get { return _issnRegex; } }

        internal static string CleanISSN (string issn)
        {
            return IssnRegex.Replace(issn.Trim(), "");
        }

        internal static string SetMaxLength(string str, int length)
        {
            if (str == null)
                return "";

            if (str.Length > length)
                return str.Substring(0, length).Trim();

            return str.Trim();
        }

        internal static decimal? ParseIntegerOrNull(string numero)
        {
            if (numero != null && numero != "")
                return decimal.Parse(numero);
            else
                return 0;
        }

        internal static string Fills(string codigo, int lenght)
        {
            while (codigo.Length < lenght)
                codigo += " ";

            return codigo;
        }

        internal static Nullable<DateTime> ParseToDateTimeOrNull(string stringDate)
        {
            if (stringDate != null && stringDate != "")
                return DateTime.ParseExact(stringDate, "ddMMyyyy", null);

            return null;
        }

        internal static string ParseDateFormat(string format)
        {
            if (format == "DDMMAAAA")
                return "ddMMyyyy";

            return format;
        }

        internal static DateTime? ParseMonthAndYear(string mes, string ano)
        {
            if (mes == null || mes == "")
                return null;

            if (ano == null || ano == "")
                return null;

            return new DateTime(int.Parse(ano), int.Parse(mes), 1);
        }
    }
}
