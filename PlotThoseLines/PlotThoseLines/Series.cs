using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotThoseLines
{
    internal static class Series
    {
        private static List<Serie> _series = new List<Serie>();

        public static List<Serie> GetSeries()
        {
            return _series;
        }

        public static void SetSeries(List<Serie> s)
        {
            _series = s;
        }

        public static void AddSerie(Serie s)
        {
            _series.Add(s);
        }
    }
}
