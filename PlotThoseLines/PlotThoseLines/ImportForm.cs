using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.Data;

namespace PlotThoseLines
{
    public partial class ImportForm : Form
    {
        public ImportForm()
        {
            InitializeComponent();
        }

        private void ImportFile()
        {
            string fileName = "imf-dm-export-20250829.xls";

            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);

            DataSet content = reader.AsDataSet();
            DataTable table = content.Tables[0];

            //DataRow et DataColumn ne supportes pas le .ForEach
            // On all tables' rows
            List<Double> XaxisValue = table.Rows[0].ItemArray.ToList().Skip(1).Select(x => double.Parse(x.ToString())).ToList();
            foreach (DataRow row in table.Rows)
            {
                Serie s = new Serie(row[0].ToString(), XaxisValue, new List<double>());
                // On all tables' columns
                foreach (DataColumn col in table.Columns)
                {
                    if (col.Ordinal != 0)
                    {
                        
                        var cell = row[col].ToString();
                        if (cell != "")
                        {
                            if (cell != "no data")
                            {
                                s.YaxisValue.Add(double.Parse(cell));
                            }
                            else
                            {
                                s.YaxisValue.Add(0);
                            }
                        }
                    }
                    
                }
                Series.AddSerie(s);
            }

            reader.Close();
            stream.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImportFile();
        }
    }
}
