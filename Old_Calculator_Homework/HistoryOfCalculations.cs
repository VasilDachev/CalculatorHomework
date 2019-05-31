using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Old_Calculator_Homework
{
    public partial class HistoryOfCalculations : Form
    {
        public HistoryOfCalculations()
        {
            InitializeComponent();
        }

        private void HistoryOfCalculations_Load(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("highscore.txt", FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        tbHistory.Text += line + Environment.NewLine;

                    }
                    tbHistory.Lines = tbHistory.Lines.OrderBy(line => line).ToArray();
                }
            }
        }
    }
}
