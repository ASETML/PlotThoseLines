using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotThoseLines
{
    class Serie
    {
        public int Id { get; set; }

        //public static Id;
        public string Name { get; set; }
        public List<double> XaxisValue { get; set; }
        public List<double> YaxisValue { get; set; }
        public bool IsDisplayed { get; set; }
        
        public Serie(string name, List<double> x, List<double> y) {
            this.Name = name;
            this.XaxisValue = x;
            this.YaxisValue = y;
            this.IsDisplayed = true;
        }

        public override string ToString()
        {
            return $"Série {Name} avec les valeurs {XaxisValue} en abscisse et {YaxisValue} en ordonnée. Afficher: {IsDisplayed}";
        }
    }
}
