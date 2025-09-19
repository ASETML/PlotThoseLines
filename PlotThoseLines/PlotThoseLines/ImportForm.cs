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

            // On all tables' rows
            foreach (DataRow row in table.Rows)
            {
                Serie s = new Serie(row[0].ToString(), new double[] {}, new double[] { });
                Trace.WriteLine(s.ToString());  
                // On all tables' columns
                foreach (DataColumn col in table.Columns)
                {
                    if (col.Ordinal != 0)
                    {
                        s.XaxisValue[s.XaxisValue.Length] = double.Parse(row[col].ToString());
                        var field1 = row[col].ToString();
                        Trace.Write(field1 + " ");
                    }
                    
                }
                Trace.Write("\n");
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
