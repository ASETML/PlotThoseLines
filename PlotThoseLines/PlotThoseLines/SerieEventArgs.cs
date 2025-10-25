using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlotThoseLines
{
    public class SerieEventArgs : EventArgs
    {
        public Serie serie { get; set; }
        public SerieEventArgs(Serie s) {
            this.serie = s;
        }
    }
}
