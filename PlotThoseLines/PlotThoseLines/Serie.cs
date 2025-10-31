using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotThoseLines
{
    public class Serie
    {
        public int Id { get; set; }

        private static int _idGenerator = 0;
        public string Name { get; set; }
        public List<double> XaxisValue { get; set; }
        public List<double> YaxisValue { get; set; }
        public bool IsDisplayed { get; set; }
        public ScottPlot.Color Color { get; set; }
        
        public Serie(string name, List<double> x, List<double> y) {
            this.Id = _idGenerator++;
            this.Name = name;
            this.XaxisValue = x;
            this.YaxisValue = y;
            this.IsDisplayed = true;
            this.Color = ScottPlot.Color.RandomHue();
        }

        public Serie(int id, string name, bool isDisplayed, string color)
        {
            this.Id = id;
            _idGenerator = id + 1;
            this.Name = name;
            this.XaxisValue = new List<double>();
            this.YaxisValue = new List<double>();
            this.IsDisplayed = isDisplayed;
            this.Color = ScottPlot.Color.FromHex(color);
        }

        public void ChangeColor(Color color)
        {
            this.Color = ScottPlot.Color.FromColor(color);
        }

        public override string ToString()
        {
            return $"Série {Id}: {Name} avec {XaxisValue.Count} valeurs en abscisse et {YaxisValue.Count} valeurs en ordonnée. Afficher: {IsDisplayed}";
        }
    }
}
