using PSI2.Models;
using PSI2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSI2
{
    public partial class JurnalActivitati : Form
    {
        private Logger _logger = new Logger();
        List<LogModel> loglist;

        public JurnalActivitati()
        {
            InitializeComponent();
        }

        private void JurnalActivitati_Load(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Add("five", "six", "seven", "eight");
            //this.dataGridView1.Rows.Insert(0, "one", "two", "three", "four");
            loglist = _logger.GetAllLogs();
            foreach (LogModel log in loglist)
            {
                dataGridView1.Rows.Add(log.LogID, Convert.ToDateTime(log.OperationDate).ToShortDateString(),Convert.ToDateTime(log.OperationDate).ToShortTimeString(), log.Username, log.OperationDescription);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
